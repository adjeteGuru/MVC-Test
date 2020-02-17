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
        public int crewId { get; set; }
        public Guid JobId { get; set; }
               
        public int has_RoleId { get; set; }
        public DateTime? start_date { get; set; }
        public DateTime? end_date { get; set; }
        public double totalDays { get; set; }
      
       
        //public int quatity { get; set; }
         public virtual Jobs Job { get; set; }
        public virtual Has_Role Has_Role { get; set; }
    }
}