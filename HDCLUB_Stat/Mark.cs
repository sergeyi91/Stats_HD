using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HDCLUB_Stat
{
   // XMLSerializer works only with public classes
   public class Mark
   {
      public int idDate;
      public double upload;

      public Mark(int date, double u)
      {
         idDate = date;
         upload = u;
      }

      public Mark()
      {
      }
   }
}
