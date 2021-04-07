using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace STI_Finfo
{
    public class Request
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Suffix { get; set; }

    }
}