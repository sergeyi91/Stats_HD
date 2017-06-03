using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HDCLUB_Stat
{
   // XMLSerializer works only with public classes
   //public class BaseOfTorrents
   //{
   //   public int numberOfDates;
   //   public List<DateTime> dates;
   //   public int numberOfTorrents;
   //   public List<Torrent> torrents;
   //   public BaseOfTorrents()
   //   {
   //      dates = new List<DateTime>();
   //      torrents = new List<Torrent>();
   //      numberOfDates = 0;
   //      numberOfTorrents = 0;
   //   }

   //   public void AddInfo(string nameTorrent, int idTorrent, int dateIndex, double uploadInMb)
   //   {
   //      Torrent t = GetTorrent(idTorrent);
   //      if (t == null) {
   //            t = new Torrent();
   //            t.name = nameTorrent;
   //            t.id = idTorrent;
   //            torrents.Add(t);
   //            numberOfTorrents++;
   //      }
   //      t.marks.Add(new Mark(dateIndex, uploadInMb));
   //      t.countMarks++;
   //   }

   //   public int IndexOfDate(DateTime date)
   //   {
   //      return dates.IndexOf(date);
   //   }

   //   public Torrent GetTorrent(int id)
   //   {
   //      foreach (Torrent t in torrents)
   //      {
   //         if (t.id == id)
   //         {
   //            return t;
   //         }
   //      }
   //      return null;
   //   }
   //}

   public class BaseOfTorrents
   {
      public int numberOfDates;
      public List<DateTime> dates;
      public int numberOfTorrents;
      public List<Torrent> torrents;
      public BaseOfTorrents()
      {
         dates = new List<DateTime>();
         torrents = new List<Torrent>();
         numberOfDates = 0;
         numberOfTorrents = 0;
      }

      public void AddInfo(string nameTorrent, string quality, int idTorrent, int dateIndex, double uploadInMb)
      {
         Torrent t = GetTorrent(idTorrent);
         //TODO найти по имени

         if (t == null)
         {
            t = new Torrent();
            t.name = nameTorrent;
            t.quality = quality;
            t.id = idTorrent;
            torrents.Add(t);
            numberOfTorrents = torrents.Count;
         }
         else
         {
            t.name = nameTorrent;
            t.quality = quality;
         }
         t.marks.Add(new Mark(dateIndex, uploadInMb));
         t.countMarks++;
      }

      public int IndexOfDate(DateTime date)
      {
         return dates.IndexOf(date);
      }

      public Torrent GetTorrent(int id)
      {
         foreach (Torrent t in torrents)
         {
            if (t.id == id)
            {
               return t;
            }
         }
         return null;
      }
   }
}
