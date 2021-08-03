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
        public List<Faculty> faculty { get; set; }
        public List<Department> department { get; set; }
        public List<Lecture> lecture { get; set; }
        public List<CRN> crn { get; set; }
        public List<int> friends { get; set; }
    }
}