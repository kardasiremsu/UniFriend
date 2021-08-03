﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniFriend.Models
{
    public class AddFriendPageModel
    {
        public List<Faculty> Faculties { get; set; }
    }

    public class Faculty
    {
        public int ID { get; set; }
        public string name { get; set; }
        public List<Department> departments { get; set; }
}

    public class Department
    {
        public int ID { get; set; }
        public string name { get; set; }
        public List<Lecture> lectures { get; set; }
    }
    public class Lecture
    {
        public int ID { get; set; }
        public string name { get; set; }
        public List<CRN> crns { get; set; }
    }
    public class CRN
    {
        public int ID { get; set; }
        public string code { get; set; }
        public List<Student> students { get; set; }
    }

}