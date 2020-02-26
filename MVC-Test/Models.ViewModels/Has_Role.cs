using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Test.Models.ViewModels
{
    public class Has_Role
    {
        public int Id { get; set; }
        public int employeeId { get; set; }
       // public string employeeName { get; set; }

         public int roleId { get; set; }
        //public string roleName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? start_date { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? end_date { get; set; }
        //public double totalDays { get; set; }
        public Decimal rate { get; set; }



    }
}