using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Test.Models
{
    public enum Category
    {
        Staff, Freelance, Contracted
    }
    public class Employee
    {
        [Key]
        [Required]
        public  int Id { get; set; } 
        public  string fullName { get; set; }
       
        public  string mobile { get; set; }
        public  string email { get; set; }

        public Category Category { get; set; }
        public  int countyId { get; set; }
        public  string bared { get; set; }
        public virtual County County { get; set; }
       
        public  bool isAvailable { get; set; }
    
        public  DateTime? start_date { get; set; }
        public  string photo { get; set; }
        public  string nextOfKin { get; set; }
        public  string alergy { get; set; }
        public  string note { get; set; }
        public  string postNominals { get; set; }
                           
    

            }
}