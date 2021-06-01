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
        public string Age { get; set; }
        public string Number { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public string sac { get; set; }
   
        public string TimeIn { get; set; }
        public string TimeOut{ get; set; }
        public string DateGuest { get; set; }
        public bool IsVisible { get; set; }
        public string FullName { get { return LastName + " " + Suffix + ", " + FirstName + " " + MiddleName; } }

    }
    public class AdminRequest
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Suffix { get; set; }
        public string Age { get; set; }
        public string Number { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public string sac { get; set; }
        public string TimeIn { get; set; }
        public string TimeOut { get; set; }
        public bool IsVisible { get; set; }
        public string DateGuest { get; set; }
        public string FullName { get { return LastName + " " + Suffix +", " + FirstName + " " + MiddleName; } }
    }


}