using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Test.Models.ViewModels
{
    public class ScheduleEdit
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "Job ID")]
        public string JobId { get; set; }

        [Display(Name = "Title")]
        public string text { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start date")]
        public DateTime? start_date { get; set; }

        [DataType(DataType.Date)]
       [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "End date")]
        public DateTime? end_date { get; set; }
        [Display(Name = "Schedule Type")]
        public SchType SchType { get; set; }

    }
}