using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mediflow.Models
{
    public class post
    {
        public int id { get; set; }
        public string title { get; set; }
        public string slug { get; set; }
        public string description { get; set; }
        public int categoryId { get; set; }
        public string image { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
        public string metaDescription { get; set; }
        public string metaKeyword { get; set; }
        public bool status { get; set; }
        public int userId { get; set; }
        public string categoryName { get; set; }
        
        
    }
}