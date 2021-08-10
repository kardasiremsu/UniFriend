using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniFriend.Models
{
    public class HomePageModel
    {
        public List<int> posts { get; set; }
    }
    public class Post
    {
        public int ID { get; set; }
        public string text { get; set; }
        public int file { get; set; }
        public int AuthorID { get; set; }
        public DateTime date { get; set; }
        public List<int> likes { get; set; }
        public List<int> comments { get; set; }
    }

    public class Comment
    {
        public int ID { get; set; }
        public string text { get; set; }
        public int AuthorID { get; set; }
        public DateTime date { get; set; }
        public List<int> likes { get; set; }
    }
}