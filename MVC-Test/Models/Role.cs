﻿using System;
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
        public  int Id { get; set; }
        public  string name { get; set; }
       
    }
}