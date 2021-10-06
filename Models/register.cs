using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mediflow.Models
{
    public class register
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string new_pwd { get; set; }
        public string old_pwd { get; set; }
        public string confirmPassword { get; set; }
        public DateTime dateTime { get; set; }
        public string email { get; set; }
        public string occupation { get; set; }
        public string about { get; set; }
        public string socialMedia { get; set; }
        public string facebook { get; set; }
        public string twitter { get; set; }
        public string youtube { get; set; }
        public string instagram { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
        public string image { get; set; }

    }
}