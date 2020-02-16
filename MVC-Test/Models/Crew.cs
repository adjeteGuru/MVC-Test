using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Test.Models
{
    public class Crew
    {
        [Key]
        [Required]

        public int crewId { get; set; }
        public int has_RoleId { get; set; }
        public Guid JobId { get; set; }

        public DateTime? start_date { get; set; }
        public DateTime? end_date { get; set; }
        public double totalDays { get; set; }
       // public Decimal rate { get; set; }
       
        public int quatity { get; set; }
        // public virtual Jobs Job { get; set; }
        public virtual Has_Role Has_Role { get; set; }
    }
}