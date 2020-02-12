using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Test.Models.ViewModels
{
    public class ScheduleEdit
    {
        public int Id { get; set; }

        public string JobId { get; set; }

        [Display(Name = "Name")]
        public string text { get; set; }

        public DateTime? start_date { get; set; }
        public DateTime? end_date { get; set; }
        public SchType SchType { get; set; }

    }
}