using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace STI_Finfo
{
    public class NoID
    {
        [PrimaryKey, AutoIncrement]
        public int NoId { get; set; }
    
        public string StudentNumber { get; set; }
      
        public string Account { get; set; }
  
        public string Reasons { get; set; }
        
        public string DateNoID { get; set; }



    }

   public class AdminNoID
    {
        [PrimaryKey, AutoIncrement]
        public int AdminNoId { get; set; }

        public string AdminStudentNumber { get; set; }

        public string AdminAccount { get; set; }

        public string AdminReasons { get; set; }

        public string AdminDateNoID { get; set; }
    }
}
