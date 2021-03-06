﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Test.Models.ViewModels
{
    public class Has_RoleEdit
    {

        

      
        [Display(Name = "ID")]
        public int has_RoleId { get; set; }

        [Display(Name = "EmployeeID")]
        //public int employeeId { get; set; }
        public string employeeName { get; set; }

        [Display(Name = "RoleID")]
        // public int roleId { get; set; }
        public string roleName { get; set; }

        [Display(Name = "Start date")]
        public DateTime? start_date { get; set; }

        [Display(Name = "End date")]
        public DateTime? end_date { get; set; }

        [Display(Name = "Rate")]
        public Decimal rate { get; set; }

    }
}