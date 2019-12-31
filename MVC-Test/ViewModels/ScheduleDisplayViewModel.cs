using MVC_Test.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Test.ViewModels
{
    public class ScheduleDisplayViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Job Name")]
        public string text { get; set; }

        [Display(Name = "Job Type")]
        public SchType SchType { get; set; }

        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]// but IT DOT NOT SUPPORT IE and Firefox
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}", ApplyFormatInEditMode = true)]
        public DateTime? start_date { get; set; }

        [Display(Name = "End Date ")]
        [DataType(DataType.Date)]// but IT DOT NOT SUPPORT IE and Firefox
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}", ApplyFormatInEditMode = true)]
        public DateTime? end_date { get; set; }

        [Display(Name = "Job ID")]
        public string JobId { get; set; }
        //public virtual Job Job { get; set; }
    }
}