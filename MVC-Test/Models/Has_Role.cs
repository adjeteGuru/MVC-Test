using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Test.Models
{
    public class Has_Role
    {
        [Key]
        [Required]
        public  int Id { get; set; }
        public  int employeeId { get; set; }
        public  int roleId { get; set; }
        public DateTime? start_date { get; set; }
        public DateTime? end_date { get; set; }
        // public double totalDays { get; set; }
        public Decimal rate { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Role Role { get; set; }
       
      

    }
}