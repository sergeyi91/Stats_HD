using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Windows.Forms;

//TODO Django Unchained and others <hide>true</hide>
//TODO удалить 75 оценки - не верны 22-12-2013
//TODO что делать с 74? сделать на основе разницы аплоада


namespace HDCLUB_Stat
{
   class HTMLParser
   {
      public static BaseOfTorrents AnalyzeHTMLByStreamReader(StreamReader htmlTextStreamReader, string baseOfTorrentsPath, ref string log)
      {
         //load base from file 'baseOfTorrentsPath'
         XmlSerializer serializer;
         try
         {
            serializer = new XmlSerializer(typeof(BaseOfTorrents));
         }
         catch (InvalidOperationException)
         {
            MessageBox.Show("XML exception: InvalidOperationException");
            return null;
         }

         BaseOfTorrents baseOfTorrents = null;
         bool fileNotFound = false;
         try
         {
            FileStream baseInputStream = new FileStream(baseOfTorrentsPath, FileMode.Open, FileAccess.Read);
            baseOfTorrents = (BaseOfTorrents)serializer.Deserialize(baseInputStream);
            baseInputStream.Close();
         }
         catch (FileNotFoundException)
         {
            fileNotFound = true;
            MessageBox.Show(String.Format("File {0} not found", baseOfTorrentsPath), "ERROR");
         }
         catch (SystemException)
         {
            MessageBox.Show("ALERT");
            return null;
         }

         if (fileNotFound)
         {
            BaseOfTorrents emptyBaseOfTorrents = new BaseOfTorrents();
            var os = new FileStream(baseOfTorrentsPath, FileMode.OpenOrCreate, FileAccess.Write);
            serializer.Serialize(os, emptyBaseOfTorrents);
            os.Close();
            MessageBox.Show(String.Format("File {0} created", baseOfTorrentsPath), "ERROR");
            return null;
         }

         //BaseOfTorrentsNew baseOfTorrents = new BaseOfTorrentsNew();
         //baseOfTorrents.numberOfDates = baseOfTorrentsOld.dates.Count;
         //baseOfTorrents.numberOfTorrents = baseOfTorrentsOld.torrents.Count;
         //for (int i = 0; i < baseOfTorrentsOld.dates.Count; ++i)
         //{
         //   baseOfTorrents.dates.Add(baseOfTorrentsOld.dates[i]);
         //}

         //for (int i = 0; i < baseOfTorrentsOld.torrents.Count; i++)
         //{
         //   Torrent t = baseOfTorrentsOld.torrents[i];
         //   TorrentNew newT = new TorrentNew();
         //   newT.countMarks = t.countMarks;
         //   newT.id = t.id;
         //   newT.marks = t.marks;
         //   newT.name = t.name;
         //   newT.quality = t.quality;
         //   newT.hide = false;
         //   baseOfTorrents.torrents.Add(newT);
         //}

         //add current date
         baseOfTorrents.dates.Add(DateTime.Now);
         int currentDateIndex = baseOfTorrents.numberOfDates;
         baseOfTorrents.numberOfDates++;

         //analyze stream 'htmlTextStreamReader'
         string line;
         bool complete = false;
         bool start = false;
         int startIndex, length;
         while (!complete && (line = htmlTextStreamReader.ReadLine()) != null)
         {
            if (!start)
            {
               if (line.Contains("javascript: show_hide('s4')"))
               {
                  start = true;
               }
            }
            else
            {
               string torrentPattern = "<b>";
               if (line.Contains(torrentPattern))
               {
                  string goldTorrentPattern = "<b><f";
                  string movie_name;
                  string quality = "UNDEFINED";
                  double uploadInMb = 0.0;
                  if (line.Contains(goldTorrentPattern))
                  {
                     //золотая раздача
                     startIndex = line.IndexOf(">", line.IndexOf(goldTorrentPattern) + goldTorrentPattern.Length) + 1;
                     length = line.IndexOf("</", line.IndexOf(goldTorrentPattern)) - startIndex;
                  }
                  else
                  {
                     //обычная раздача
                     startIndex = line.IndexOf(torrentPattern) + torrentPattern.Length;
                     length = line.IndexOf("</", line.IndexOf(torrentPattern)) - startIndex;
                  }
                  movie_name = line.Substring(startIndex, length);
                  if (movie_name.Contains(" / "))
                  {
                     //удаляем русское имя
                     movie_name = movie_name.Substring(movie_name.IndexOf(" / ") + " / ".Length);
                  }

                  //initializes "quality"
                  List<Int32> indexes = new List<Int32>();
                  int index = movie_name.IndexOf("Blu-ray");
                  if (index >= 0)
                     indexes.Add(index);
                  index = movie_name.IndexOf("HDTV");
                  if (index >= 0)
                     indexes.Add(index);
                  index = movie_name.IndexOf("720");
                  if (index >= 0)
                     indexes.Add(index);
                  index = movie_name.IndexOf("1080");
                  if (index >= 0)
                     indexes.Add(index);
                  //TODO ASSERT on indexes.Count == 0
                  indexes.Sort();
                  quality = movie_name.Substring(indexes[0]);
                  movie_name = movie_name.Substring(0, indexes[0] - 1);

                  //initializes "uploadInMb"
                  //<nobr>1.59 MB<br />950.62 MB</nobr>
                  string uploadPattern = "<br />";
                  startIndex = line.IndexOf(uploadPattern, startIndex) + uploadPattern.Length;
                  length = line.IndexOf("</nobr>", startIndex) - startIndex;
                  string uploadText = line.Substring(startIndex, length);
                  uploadText = uploadText.Replace('.', ',');
                  if (uploadText.EndsWith("MB"))
                  {
                     uploadInMb = Convert.ToDouble(uploadText.Substring(0, uploadText.Length - 3));
                  }
                  else
                  {
                     if (uploadText.EndsWith("GB"))
                     {
                        uploadInMb = Convert.ToDouble(uploadText.Substring(0, uploadText.Length - 3)) * 1024.0;
                     }
                     else
                     {
                        if (uploadText.EndsWith("kB"))
                        {
                           uploadInMb = Convert.ToDouble(uploadText.Substring(0, uploadText.Length - 3)) / 1024.0;
                        }
                     }
                  }

                  //initializes "ID"
                  //<a href="details.php?id=298&amp;hit=1">
                  string idPattern = "?id=";
                  startIndex = line.IndexOf(idPattern) + idPattern.Length;
                  length = line.IndexOf("&amp", line.IndexOf(idPattern)) - startIndex;
                  int id = Convert.ToInt32(line.Substring(startIndex, length));

                  //check active
                  //<font color="green">Да</font></td>
                  bool active = true;
                  string activePattern = "<font";
                  string tmp = line.Substring(line.LastIndexOf(activePattern) + activePattern.Length);
                  if (tmp.Contains("red"))
                     active = false;
                  else
                     if (tmp.Contains("green"))
                        active = true;
                     else
                     {
                        //TODO ALERT
                     }

                  if (active || baseOfTorrents.GetTorrent(id) == null)
                  {
                     baseOfTorrents.AddInfo(movie_name, quality, id, currentDateIndex, uploadInMb);
                  }
               }
               else
               {
                  if (line.Contains("</table>"))
                  {
                     complete = true;
                     htmlTextStreamReader.Close();
                  }
               }
            }
         }

         //rewrite new base file
         //FileStream baseOutputStream = new FileStream(@"D:\HDCLUB_BaseTmp.xml", FileMode.OpenOrCreate, FileAccess.Write);
         //XmlSerializer serializerNew = new XmlSerializer(typeof(BaseOfTorrentsNew));

         FileStream baseOutputStream = new FileStream(baseOfTorrentsPath, FileMode.OpenOrCreate, FileAccess.Write);
         serializer.Serialize(baseOutputStream, baseOfTorrents);
         baseOutputStream.Close();

         return baseOfTorrents;
      }
   }
}
