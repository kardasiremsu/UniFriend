using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniFriend.Models
{
    public class ClubsPageModel
    {
       public List<Club> clubs { get; set; }

    }

    public class Club
    {
        public int ID { get; set; }
        public string name { get; set; }
        public List<int> students { get; set; }
        
    }
}