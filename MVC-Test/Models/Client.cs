using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Test.Models
{
    public class Client
    {
        [Display(Name = "Client ID")]
        public string Id { get; set; }

        [Display(Name = "Client Name")]
        public string name { get; set; }

        [Display(Name = "Tel")]
        public int tel { get; set; }

        [Display(Name = "Email")]
        public string email { get; set; }

        [Display(Name = "T Contact")]
        public string toContact { get; set; }

        [Display(Name = "Adrress")]
        public string address { get; set; }

        public virtual Client Clients { get; set; }
    }
}