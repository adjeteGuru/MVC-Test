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
        [Display(Name = "Employee ID")]
        public  int Id { get; set; }

        [Display(Name = "FullName")]
        public  string fullName { get; set; }

        [Display(Name = "Mobile")]

        public  string mobile { get; set; }

        [Display(Name = "Email")]
        public  string email { get; set; }

       
        public Category Category { get; set; }

        [Display(Name = "County")]
        public  int countyId { get; set; }

        [Display(Name = "Is_Bared?")]
        public  string bared { get; set; }
        public virtual County County { get; set; }

        [Display(Name = "Available")]
        public  bool isAvailable { get; set; }

        [Display(Name = "Date joined")]
        public  DateTime? start_date { get; set; }

        [Display(Name = "Photo")]
        public  string photo { get; set; }

        [Display(Name = "NextOfKin")]
        public  string nextOfKin { get; set; }

        [Display(Name = "Alergy")]
        public  string alergy { get; set; }

        [Display(Name = "Note")]
        public  string note { get; set; }

        [Display(Name = "Post Nominals")]
        public  string postNominals { get; set; }
                           
    

            }
}