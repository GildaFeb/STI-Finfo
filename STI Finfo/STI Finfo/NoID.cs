using SQLite;
using System;
using System.Collections.Generic;
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

        public string DateTime1 { get; set; }
    }

   
}
