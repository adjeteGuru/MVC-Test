using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Test.Models
{
    public class Employee
    { public Employee()
        {
            Has_Roles = new HashSet<Has_Role>();
        }
        public  int Id { get; set; } 
        public  string FirstName { get; set; }
        public  string LastName { get; set; }
        public  string Mobile { get; set; }
        public  string Email { get; set; }
       
        public  int CountyId { get; set; }
        public  string bared { get; set; }
        public virtual County County { get; set; }
       
        public  bool IsAvailable { get; set; }
    
        public  DateTime? StartDate { get; set; }
        public  string Photo { get; set; }
        public  string NextOfKin { get; set; }
        public  string Alergy { get; set; }
        public  string Note { get; set; }
        public  string PostNominals { get; set; }

        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
        public virtual ICollection<Has_Role> Has_Roles { get; set; }
       // public virtual ICollection<Schedule> Schedules { get; set; }
        public virtual ICollection<Crew> Crews { get; set; }
      
    


    }
}