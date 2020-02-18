using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Test.Models
{
    public class Role
    {
        [Key]
        [Required]

        [Display(Name = "ID")]
        public  int Id { get; set; }

        [Display(Name = "Title")]
        public  string name { get; set; }
       
    }
}