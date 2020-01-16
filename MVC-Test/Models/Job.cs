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
    { public Job()
        {
            Schedules = new HashSet<Schedule>();
            Crews = new HashSet<Crew>();
        }
        public  string Id { get; set; }
        public  string text { get; set; }
        public  string Description { get; set; }
        public  string Location { get; set; }
        public  DateTime? DateCreated { get; set; }
        public  DateTime? start_date { get; set; }
        public DateTime? TXDate { get; set; }
        public  DateTime? end_date { get; set; }
        public  string Coordinator { get; set; }
        public  string CommercialLead { get; set; }
        public  int ClientId { get; set; }
        public Status Status { get; set; }
        public virtual Client Client { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
        public virtual ICollection<Crew> Crews { get; set; }

    }
}