using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniFriend.Models
{
    public class AddFriendPageModel
    {
        public int userid { get; set; }
        public List<int> faculties { get; set; }
    }

    public class Faculty
    {
        public int ID { get; set; }
        public string name { get; set; }
        public List<int> departments { get; set; }
    }

    public class Department
    {
        public int ID { get; set; }
        public string name { get; set; }
        public List<int> lectures { get; set; }
    }

    public class Lecture
    {
        public int ID { get; set; }
        public string name { get; set; }
        public List<int> crns { get; set; }
    }

    public class CRN
    {
        public int ID { get; set; }
        public string code { get; set; }
        public List<int> students { get; set; }
    }

}