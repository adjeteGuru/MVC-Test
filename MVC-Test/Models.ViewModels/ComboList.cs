﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Test.Models.ViewModels
{
    public class ComboList
    {
        [StringLength(38)]
        public string JobId { get; set; }

        public ICollection<Has_Role> Has_Roles { get; set; }

        public ICollection<Role> Roles { get; set; }
        public ICollection<Employee> Employees { get; set; }
       // public ICollection<ComboClassesViewModel> ComboClasses { get; set; }
    }
}