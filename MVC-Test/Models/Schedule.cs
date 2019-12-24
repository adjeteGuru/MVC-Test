using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Test.Models
{ public enum SchType
    {
        TrucksTravel, CableRig, TechRig, Rehersal, RX, TX, DeRig, DarkDay, Facs, TrucksReturn

    }
    public class Schedule
    {
        public Schedule()
        {
            Has_Roles = new HashSet<Has_Role>();
            //Employees = new HashSet<Employee>();
        }
        public  int Id { get; set; }
        public  string text { get; set; }
      
        public  DateTime? start_date { get; set; }
        public  DateTime? end_date { get; set; }
        public SchType SchType { get; set; }

        public  string JobId { get; set; }
        public virtual Job Job { get; set; }
     
       // public virtual ICollection<Crew> Crews { get; set; }

        //new
        public virtual ICollection<Has_Role> Has_Roles { get; set; }
        //new
        //public virtual ICollection<Employee>Employees { get; set; }

    }
}