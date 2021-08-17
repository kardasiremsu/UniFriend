using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniFriend.Models
{
    public class ClubProfileModel
    {
        public int ID { get; set; }
        public string name { get; set; }
        public Dictionary<int,string> students { get; set; }
    }
}