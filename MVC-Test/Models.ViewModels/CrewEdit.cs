using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Test.Models.ViewModels
{
    public class CrewEdit
    {
        public int crewId { get; set; }
        public int has_RoleId { get; set; }
        //public string RoleName { get; set; }
        public string JobId { get; set; }

        [DataType(DataType.Date)]
       // [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? start_date { get; set; }

        [DataType(DataType.Date)]
       // [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? end_date { get; set; }
        public double totalDays { get; set; }
        // public Decimal rate { get; set; }

        public int quatity { get; set; }
    }
}