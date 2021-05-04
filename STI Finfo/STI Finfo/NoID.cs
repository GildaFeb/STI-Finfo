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
        [Required, System.ComponentModel.DataAnnotations.MaxLength(11)]
        public string StudentNumber { get; set; }
        [Required, System.ComponentModel.DataAnnotations.MaxLength(50)]
        public string Account { get; set; }
        [Required, System.ComponentModel.DataAnnotations.MaxLength(50)]
        public string Reasons { get; set; }
        
        public string DateNoID { get; set; }
    }

   
}
