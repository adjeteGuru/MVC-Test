using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Test.Models
{ public enum SchType
    {
        TrucksTravel, CableRig, TechRig, Rehersal, RX, TX, DeRig, DarkDay, Facs, TrucksReturn

    }
    public class Schedule
    {
        [Key]
        [Required]

        [Display(Name = "ID")]
        public  int Id { get; set; }

        [Required]
        [Display(Name = "Job ID")]
        public Guid JobId { get; set; }

        [Display(Name = "Title")]
        public  string text { get; set; }

        [Display(Name = "Start date")]
        public  DateTime? start_date { get; set; }

        [Display(Name = "End date")]
        public  DateTime? end_date { get; set; }

        [Display(Name = "Schedule type")]
        public SchType SchType { get; set; }

       
        public virtual Jobs Job { get; set; }

     
     
    }
}