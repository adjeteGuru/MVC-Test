using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Test.Models
{
    public class Crew
    {
        public int Id { get; set; }
        public virtual string JobId { get; set; }
        public virtual int Has_RoleId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public double TotalDays { get; set; }
        public Decimal Rate { get; set; }
        public virtual Job Job { get; set; }
        public virtual Has_Role Has_Role { get; set; }
    }
}