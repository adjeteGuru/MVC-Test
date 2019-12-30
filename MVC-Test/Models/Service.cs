using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Test.Models
{
    public class Service
    {
        public int Id { get; set; }
        public virtual int ScheduleId { get; set; }
        public virtual int Has_RoleId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public double totalDays { get; set; }
        public Decimal Rate { get; set; }
        public virtual Schedule Schedule { get; set; }
        public virtual Has_Role Has_Role { get; set; }
    }
}