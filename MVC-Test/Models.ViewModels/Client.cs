using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Test.Models.ViewModels
{
    public class Client
    {
        public string Id { get; set; }
        public string name { get; set; }
        public int tel { get; set; }
        public string email { get; set; }
        public string toContact { get; set; }
        public string address { get; set; }
    }
}