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
        [Display(Name = "ID")]
        public  int has_RoleId { get; set; }

        [Display(Name = "EmployeeID")]
        public  int employeeId { get; set; }

        [Display(Name = "RoleID")]
        public  int roleId { get; set; }

        [Display(Name = "Start date")]
        public DateTime? start_date { get; set; }

        [Display(Name = "End date")]
        public DateTime? end_date { get; set; }

        [Display(Name = "Rate")]
        public Decimal rate { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Role Role { get; set; }
       
      

    }
}