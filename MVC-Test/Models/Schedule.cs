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
        public  int Id { get; set; }
        public  string text { get; set; }
      
        public  DateTime? start_date { get; set; }
        public  DateTime? end_date { get; set; }
        public SchType SchType { get; set; }

        public Guid JobId { get; set; }
        public virtual Jobs Job { get; set; }

     
     
    }
}