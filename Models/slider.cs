using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mediflow.Models
{
    public class slider
    {
        public int id { get; set; }
        public string title { get; set; }
        public string image { get; set; }
        public HttpPostedFile ImageFile  { get; set; }
        public bool status { get; set; }
    }
}