using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Test.Models
{
    public enum Category
    {
        Staff, Freelance, Contracted
    }
    public class Crew
    {
        public  int Id { get; set; }
        public  int ScheduleId { get; set; }
        public  int Has_RoleId { get; set; }
        public  DateTime StartTime { get; set; }
        public  DateTime EndTime { get; set; }
        public  int TotalHours { get; set; }
        public  Decimal Cost { get; set; }
        public Category Category { get; set; }
        public virtual Schedule Schedule { get; set; }
        public virtual Has_Role Has_Role { get; set; }
        
        
    }
}