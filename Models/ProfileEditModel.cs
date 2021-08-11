using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniFriend.Models
{
    public class ProfileEditModel
    {
     
        public int ID { get; set; }
        public string stud_name { get; set; }
        public string stud_number { get; set; }
        public char stud_gender { get; set; }
        public Dictionary<int, string> faculty { get; set; }
        public Dictionary<int, string> department { get; set; }
        public List<Lecture> lecture { get; set; }
        public List<CRN> crn { get; set; }
    }
}