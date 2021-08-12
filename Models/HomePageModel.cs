using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniFriend.Models {
    public class HomePageModel {
        public List<Post> posts { get; set; }
        public List<Student> students { get; set; }
    }
    public class Post {
        public int ID { get; set; }
        public string text { get; set; }
        public string file { get; set; }
        public int AuthorID { get; set; }
        public string date { get; set; }
        public List<int> likes { get; set; }
        public List<Comment> comments { get; set; }
    }

    public class Comment {
        public int ID { get; set; }
        public string text { get; set; }
        public int AuthorID { get; set; }
        public string date { get; set; }
        public List<int> likes { get; set; }
    }
}