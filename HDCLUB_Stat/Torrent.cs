using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HDCLUB_Stat
{
   // XMLSerializer works only with public classes
   //public class Torrent
   //{
   //   public int id;
   //   public string name;
   //   //version 1.2
   //   public string quality;
   //   public int countMarks;
   //   public List<Mark> marks;

   //   public Torrent()
   //   {
   //      marks = new List<Mark>();
   //      countMarks = 0;
   //   }
   //}

   public class Torrent
   {
      public int id;
      public string name;
      //version 1.2
      public string quality;
      public int countMarks;
      public List<Mark> marks;
      //version 1.3
      public bool hide;

      public Torrent()
      {
         marks = new List<Mark>();
         countMarks = 0;
      }
   }
}
