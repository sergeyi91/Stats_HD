using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace HDCLUB_Stat
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        BaseOfTorrents torrentBaseOfTorrents;

        private string timeFormatDDMMYYYY(DateTime dt)
        {
            return String.Format("{0:00}.{1:00}.{2:0000}", dt.Day, dt.Month, dt.Year);
        }

        private void analyze(string input_file, string BaseOfTorrents_file)
        {
           XmlSerializer serializer = new XmlSerializer(typeof(BaseOfTorrents));
           FileStream BaseOfTorrentsInputStream = new FileStream(BaseOfTorrents_file, FileMode.Open, FileAccess.Read);
           torrentBaseOfTorrents = (BaseOfTorrents)serializer.Deserialize(BaseOfTorrentsInputStream);
           BaseOfTorrentsInputStream.Close();
           torrentBaseOfTorrents.dates.Add(File.GetCreationTime(input_file));
           int currentDateIndex = torrentBaseOfTorrents.numberOfDates;
           torrentBaseOfTorrents.numberOfDates++;
           StreamReader sr = new StreamReader(new FileStream(input_file, FileMode.Open, FileAccess.Read), System.Text.Encoding.GetEncoding(1251));
           string line;
           string pat1 = "<td><nobr>";
           bool find = false;
           bool start = false;
           string pat_exit = "</tbody></table>";
           int startIndex, length;
           while (!find && (line = sr.ReadLine()) != null)
           {
              if (line.Contains(pat1))
              {
                 start = true;
                 string pat2 = "<b>";
                 string pat3 = "<b><f";
                 string movie_name;
                 double uploadInMb = 0.0;
                 if (line.Contains(pat3))
                 {
                    startIndex = line.IndexOf(">", line.IndexOf(pat3) + 2) + 1;
                    length = line.IndexOf("</", line.IndexOf(pat3)) - startIndex;
                 }
                 else
                 {
                    startIndex = line.IndexOf(pat2) + pat2.Length;
                    length = line.IndexOf("</", line.IndexOf(pat2)) - startIndex;
                 }
                 movie_name = line.Substring(startIndex, length);
                 if (movie_name.Contains(" / "))
                 {
                    movie_name = movie_name.Substring(movie_name.LastIndexOf(" / ") + 3);
                 }
                 if (movie_name.Contains("Blu-ray"))
                 {
                    movie_name = movie_name.Substring(0, movie_name.IndexOf("Blu-ray") - 1);
                 }
                 else
                 {
                    if (movie_name.Contains("HDTV"))
                    {
                       movie_name = movie_name.Substring(0, movie_name.IndexOf("HDTV") - 1);
                    }
                 }
                 if (movie_name.Contains("720"))
                 {
                    movie_name = movie_name.Substring(0, movie_name.IndexOf("720") - 1);
                 }
                 else
                 {
                    if (movie_name.Contains("1080"))
                    {
                       movie_name = movie_name.Substring(0, movie_name.IndexOf("1080") - 1);
                    }
                 }
                 string pat4 = "<nobr>";
                 startIndex = line.LastIndexOf(pat4) + pat4.Length;
                 length = line.LastIndexOf("</n") - startIndex;
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
                 string pat5 = "?id=";
                 startIndex = line.IndexOf(pat5) + pat5.Length;
                 length = line.IndexOf("&amp", line.IndexOf(pat5)) - startIndex;
                 int id = Convert.ToInt32(line.Substring(startIndex, length));
                 torrentBaseOfTorrents.AddInfo(movie_name, "", id, currentDateIndex, uploadInMb);
              }
              else
              {
                 if (start && line.Contains(pat_exit))
                 {
                    find = true;
                    sr.Close();
                 }
              }
           }
           FileStream BaseOfTorrentsOutputStream = new FileStream(BaseOfTorrents_file, FileMode.OpenOrCreate, FileAccess.Write);
           serializer.Serialize(BaseOfTorrentsOutputStream, torrentBaseOfTorrents);
           BaseOfTorrentsOutputStream.Close();
        }



        private void analyzeAll(string input_file, string BaseOfTorrents_file)
        {
            torrentBaseOfTorrents = new BaseOfTorrents();
            torrentBaseOfTorrents.dates.Add(File.GetCreationTime(input_file));
            int currentDateIndex = torrentBaseOfTorrents.numberOfDates;
            torrentBaseOfTorrents.numberOfDates++;
            StreamReader sr = new StreamReader(new FileStream(input_file, FileMode.Open, FileAccess.Read), System.Text.Encoding.GetEncoding(1251));
            XmlSerializer serializer = new XmlSerializer(typeof(BaseOfTorrents));
            string line;
            string pat1 = "<tr valign=\"top\">";
            bool find = false;
            bool start = false;
            int startIndex, length;
            while (!find && (line = sr.ReadLine()) != null)
            {
                if (!start && line.StartsWith(pat1) && line.Contains("show_hide('s4')"))
                {
                    start = true;
                }
                if (start && (line.StartsWith("<tr><td") || line.StartsWith("</tr><tr>")))
                {
                    string pat2 = "<b>";
                    string pat3 = "<b><f";
                    string movie_name;
                    double uploadInMb = 0.0;
                    if (line.Contains(pat3))
                    {
                        startIndex = line.IndexOf(">", line.IndexOf(pat3) + 6) + 1;
                    }
                    else
                    {
                        startIndex = line.IndexOf(pat2) + pat2.Length;
                    }
                    length = line.IndexOf("</", startIndex) - startIndex;
                    movie_name = line.Substring(startIndex, length);
                    if (movie_name.Contains(" / "))
                    {
                        movie_name = movie_name.Substring(movie_name.LastIndexOf(" / ") + 3);
                    }
                    if (movie_name.Contains("Blu-ray"))
                    {
                        movie_name = movie_name.Substring(0, movie_name.IndexOf("Blu-ray") - 1);
                    }
                    else
                    {
                        if (movie_name.Contains("HDTV"))
                        {
                            movie_name = movie_name.Substring(0, movie_name.IndexOf("HDTV") - 1);
                        }
                    }
                    if (movie_name.Contains("720"))
                    {
                        movie_name = movie_name.Substring(0, movie_name.IndexOf("720") - 1);
                    }
                    else
                    {
                        if (movie_name.Contains("1080"))
                        {
                            movie_name = movie_name.Substring(0, movie_name.IndexOf("1080") - 1);
                        }
                    }
                    string pat4 = "><nobr>";
                    startIndex = line.IndexOf(pat4) + pat4.Length;
                    length = line.IndexOf("<b", startIndex) - startIndex;
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
                    string pat5 = "?id=";
                    startIndex = line.IndexOf(pat5) + pat5.Length;
                    length = line.IndexOf("&amp", line.IndexOf(pat5)) - startIndex;
                    int id = Convert.ToInt32(line.Substring(startIndex, length));
                    torrentBaseOfTorrents.AddInfo(movie_name, "", id, currentDateIndex, uploadInMb);
                }
                else
                {
                    if (start && line.Contains("</tr></tbody></table></div></td></tr>"))
                    {
                        find = true;
                        sr.Close();
                    }
                }
            }
            serializer.Serialize(new FileStream(BaseOfTorrents_file, FileMode.OpenOrCreate, FileAccess.Write), torrentBaseOfTorrents);
        }

        private void printResults(string BaseOfTorrents_file, string output_file)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(BaseOfTorrents));
            FileStream BaseOfTorrentsInputStream = new FileStream(BaseOfTorrents_file, FileMode.Open, FileAccess.Read);
            torrentBaseOfTorrents = (BaseOfTorrents)serializer.Deserialize(BaseOfTorrentsInputStream);
            BaseOfTorrentsInputStream.Close();
            int[] id = new int[torrentBaseOfTorrents.numberOfTorrents];
            double[] upload = new double[torrentBaseOfTorrents.numberOfTorrents];
            for (int i = 0; i < torrentBaseOfTorrents.numberOfTorrents; i++)
            {
                Torrent t = torrentBaseOfTorrents.torrents[i];
                upload[i] = t.marks[t.countMarks - 1].upload;
                id[i] = i;
            }
            for (int i = 0; i < torrentBaseOfTorrents.numberOfTorrents - 1; i++)
            {
                for (int j = i + 1; j < torrentBaseOfTorrents.numberOfTorrents; j++)
                {
                    if (upload[i]<upload[j]) {
                        double tmp1 = upload[i];
                        upload[i] = upload[j];
                        upload[j] = tmp1;
                        int tmp2 = id[i];
                        id[i] = id[j];
                        id[j] = tmp2;
                    }
                }
            }
            StreamWriter sw = new StreamWriter(new FileStream(output_file, FileMode.Create, FileAccess.Write));
            for (int i=0; i<torrentBaseOfTorrents.numberOfTorrents; i++) {
                Torrent t = torrentBaseOfTorrents.torrents[id[i]];
                bool isUploadNow = (t.marks[t.countMarks-1].idDate==torrentBaseOfTorrents.numberOfDates-1);
                sw.Write(String.Format("{0}\t{3}\t{1:000000.000}\t{2}\n", i+1, upload[i], t.name, isUploadNow?"x":" "));
            }
            sw.Close();
        }

        private class SortInfo
        {
            public double upload;
            public int index;
            public SortInfo(int i, double u)
            {
                index = i;
                upload = u;
            }
        }

        private int sortByUpload(SortInfo a, SortInfo b)
        {
            return (a.upload > b.upload) ? -1 : ((a.upload < b.upload) ? 1 : 0);
        }

        private void makeReportForLastDate(string BaseOfTorrents_file, string output_file)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(BaseOfTorrents));
            FileStream BaseOfTorrentsInputStream = new FileStream(BaseOfTorrents_file, FileMode.Open, FileAccess.Read);
            torrentBaseOfTorrents = (BaseOfTorrents)serializer.Deserialize(BaseOfTorrentsInputStream);
            BaseOfTorrentsInputStream.Close();
            StreamWriter sw = new StreamWriter(new FileStream(output_file, FileMode.Create, FileAccess.Write));
            List<SortInfo> uploadInfo = new List<SortInfo>();
            int indexLastDate = torrentBaseOfTorrents.numberOfDates - 1;
            double sum_upload = 0;
            for (int i=0; i<torrentBaseOfTorrents.numberOfTorrents; i++)
            {
                Torrent t = torrentBaseOfTorrents.torrents[i];
                if (t.marks[t.countMarks - 1].idDate == indexLastDate)
                {
                    double u = (t.countMarks > 1) ?
                        t.marks[t.countMarks - 1].upload - t.marks[t.countMarks - 2].upload :
                        t.marks[t.countMarks - 1].upload;
                    sum_upload += u;
                    uploadInfo.Add(new SortInfo(i, u));
                }
            }
            uploadInfo.Sort(sortByUpload);
            sw.Write(String.Format("Sum upload between {1} and {0}: {2}\n\n", torrentBaseOfTorrents.dates[torrentBaseOfTorrents.numberOfDates - 1], torrentBaseOfTorrents.dates[torrentBaseOfTorrents.numberOfDates - 2], String.Format("{0:00000.00}", sum_upload).Replace(',','.')));
            for (int i = 0; i < uploadInfo.Count; i++)
            {
                Torrent t = torrentBaseOfTorrents.torrents[uploadInfo[i].index];
                String s1 = String.Format("{0:00000.000} {1:000.00}%", uploadInfo[i].upload, uploadInfo[i].upload/sum_upload*100.0).Replace(',','.');
                sw.Write(String.Format("{0} {2} {1} {3}\n", s1, timeFormatDDMMYYYY(torrentBaseOfTorrents.dates[t.marks[t.countMarks - 1].idDate]),
                        timeFormatDDMMYYYY((t.countMarks > 1) ? torrentBaseOfTorrents.dates[t.marks[t.countMarks - 2].idDate] : torrentBaseOfTorrents.dates[t.marks[t.countMarks - 1].idDate]),
                        t.name));
            }
            sw.Close();
        }

        private void uploadLive(string BaseOfTorrents_file, string output_file)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(BaseOfTorrents));
            FileStream BaseOfTorrentsInputStream = new FileStream(BaseOfTorrents_file, FileMode.Open, FileAccess.Read);
            torrentBaseOfTorrents = (BaseOfTorrents)serializer.Deserialize(BaseOfTorrentsInputStream);
            BaseOfTorrentsInputStream.Close();
            StreamWriter sw = new StreamWriter(new FileStream(output_file, FileMode.Create, FileAccess.Write));
            List<SortInfo> uploadLiveInfo = new List<SortInfo>();
            for (int i = 0; i < torrentBaseOfTorrents.numberOfTorrents; i++)
            {
                Torrent t = torrentBaseOfTorrents.torrents[i];
                int uploadInDays = 0;
                for (int j = 1; j < t.countMarks; j++)
                {
                    uploadInDays += (torrentBaseOfTorrents.dates[t.marks[j].idDate].Date - torrentBaseOfTorrents.dates[t.marks[j-1].idDate].Date).Days;
                }
                uploadLiveInfo.Add(new SortInfo(i, uploadInDays));
            }
            uploadLiveInfo.Sort(sortByUpload);
            sw.Write(String.Format("Sum upload days between {0} and {1}: {2}\n\n", torrentBaseOfTorrents.dates[0], torrentBaseOfTorrents.dates[torrentBaseOfTorrents.numberOfDates - 1], (torrentBaseOfTorrents.dates[torrentBaseOfTorrents.numberOfDates - 1].Date - torrentBaseOfTorrents.dates[0].Date).Days));
            int idLastDate = torrentBaseOfTorrents.numberOfDates - 1;
            for (int i = 0; i < uploadLiveInfo.Count; i++)
            {
                Torrent t = torrentBaseOfTorrents.torrents[uploadLiveInfo[i].index];
                //String uploadString = String.Format("{0:00000.000}", t.marks[t.countMarks-1].upload).Replace(',', '.');
                sw.Write(String.Format("{0} {1:0} {2}\n", (t.marks[t.countMarks-1].idDate==idLastDate ? "x":" "), uploadLiveInfo[i].upload, t.name));
            }
            sw.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
         //XmlSerializer serializer;
         //try
         //{
         //   serializer = new XmlSerializer(typeof(BaseOfTorrents));
         //}
         //catch (InvalidOperationException)
         //{
         //   MessageBox.Show("XML exception: InvalidOperationException");
         //   return;
         //}
         //BaseOfTorrents emptyBaseOfTorrents = new BaseOfTorrents();
         //var os = new FileStream(inputFileTextBox.Text, FileMode.OpenOrCreate, FileAccess.Write);
         //serializer.Serialize(os, emptyBaseOfTorrents);
         //os.Close();
         //MessageBox.Show(String.Format("File {0} created", inputFileTextBox.Text), "ERROR");

         if (analyzeAllCheckBox.Checked)
         {
            analyzeAll(inputFileTextBox.Text, baseOfTorrentsPathTextBox.Text);
         }
         else
         {
            analyze(inputFileTextBox.Text, baseOfTorrentsPathTextBox.Text);
         }
      }

        private void button2_Click(object sender, EventArgs e)
        {
            printResults(baseOfTorrentsPathTextBox.Text, resultsFileTextBox.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            makeReportForLastDate(baseOfTorrentsPathTextBox.Text, reportFileTextBox.Text);
        }

        private void uploadLiveButton_Click(object sender, EventArgs e)
        {
            uploadLive(baseOfTorrentsPathTextBox.Text, uploadLiveTextBox.Text);
        }

        private void editBaseOfTorrentsButton_Click(object sender, EventArgs e)
        {
            EditBaseOfTorrentsForm form = new EditBaseOfTorrentsForm();
            form.Visible = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenSiteForm form = new OpenSiteForm();
            form.Visible = true;
        }
    }
}
