 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Test.Models.ViewModels
{
    public class ComboClassesViewModel
    {
        //CREW ATTRIBUTES
        public int crewId { get; set; }
        //public int has_RoleId { get; set; }
      
        public string JobId { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start date")]
        public DateTime? start_date { get; set; }


        [Display(Name = "Start date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? end_date { get; set; }

        [Range(typeof(decimal), "30.00", "1000.00")]
        public double totalDays { get; set; }

       

        //HAS_ROLE ATTRIBUTES
       // public int has_RoleId { get; set; }
        public Decimal rate { get; set; }


        //EMPLOYEE ATTRIBUTES
       // public int employeeId { get; set; }

        [Display(Name = "FullName")]
        public string fullName { get; set; }



        //ROLE ATTRIBUTES
       // public int roleId { get; set; }

        [Display(Name = "Title")]
        public string name { get; set; }




    }
}