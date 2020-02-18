using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_Test.Models
{
    public class Crew
    {
     

        [Key]
        [Required]

        [Display(Name = "Crew ID")]
        public int crewId { get; set; }
        [Required]
        [Display(Name = "Jod ID")]
        public Guid JobId { get; set; }

        [Required]
        [Display(Name = "Has Role")]
        public int has_RoleId { get; set; }

        [Display(Name = "Start date")]
        public DateTime? start_date { get; set; }

        [Display(Name = "End date")]
        public DateTime? end_date { get; set; }

        [Display(Name = "Total days")]
        public double totalDays { get; set; }
      
       
        //public int quatity { get; set; }
         public virtual Jobs Job { get; set; }
        public virtual Has_Role Has_Role { get; set; }
    }
}