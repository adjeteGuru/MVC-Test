using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Test.Models
{
    public class Has_Role
    {
        public  int Id { get; set; }
        public  int EmployeeId { get; set; }
        public  int RoleId { get; set; }
        public  DateTime? StartTime { get; set; }
        public  DateTime? EndTime { get; set; }
        public double totalDays { get; set; }
        public Decimal Rate { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<Crew> Crews { get; set; }
      

    }
}