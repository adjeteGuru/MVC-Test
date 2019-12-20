using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Test.Models
{ public enum Status
    {
        InQuotation, Active, Cancelled, Completed
    }
    public class Job
    {
        public  string Id { get; set; }
        public  string Name { get; set; }
        public  string Description { get; set; }
        public  string Location { get; set; }
        public  DateTime DateCreated { get; set; }
        public  DateTime StartDate { get; set; }
        public DateTime TXDate { get; set; }
        public  DateTime EndDate { get; set; }
        public  string Coordinator { get; set; }
        public  string CommercialLead { get; set; }
        public  int ClientId { get; set; }
        public Status Status { get; set; }
        public virtual Client Client { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }

    }
}