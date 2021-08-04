using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniFriend.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string stud_name { get; set; }
        public string stud_number { get; set; }
        public char stud_gender { get; set; }
        public string mail { get; set; }
        public string password { get; set; }
        public List<int> faculty { get; set; }
        public List<int> department { get; set; }
        public List<int> lecture { get; set; }
        public List<int> crn { get; set; }
        public List<int> friends { get; set; }
    }
}