using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Test.Models
{
    public class County
    {
        [Display(Name = "County ID")]
        public  int Id  { get; set; }

        [Display(Name = "County")]
        public  string name { get; set; }
      
    }
}