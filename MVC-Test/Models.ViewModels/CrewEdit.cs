using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Test.Models.ViewModels
{
    public class CrewEdit
    {
        [Display(Name = "ID")]
        public int crewId { get; set; }

        [Display(Name = "Job ID")]
        public string JobId { get; set; }

       // [Display(Name = "Role")]
        public int has_RoleId { get; set; }

        public int employeeId { get; set; }
        //public string employeeName { get; set; }

         public int roleId { get; set; }
       // public string roleName { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        [Display(Name = "Start date")]
        public DateTime? start_date { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        [Display(Name = "End date")]
        public DateTime? end_date { get; set; }

        [Display(Name = "Total days")]
        public double totalDays { get; set; }
        // public Decimal rate { get; set; }
                
    }
}