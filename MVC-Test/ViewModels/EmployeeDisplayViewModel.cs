using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Test.ViewModels
{
    public class EmployeeDisplayViewModel
    {
        [Display(Name = "Employee ID")]
        public int Id { get; set; }

        [Display(Name = "Fistname")]
        public string FirstName { get; set; }

        [Display(Name = "Surname")]
        public string LastName { get; set; }

        [Display(Name = "Mobile")]
        public string Mobile { get; set; }

        [Display(Name = "Email address")]
        public string Email { get; set; }

        [Display(Name = "County")]
        public string CountyName { get; set; }
     

        [Display(Name = "Do Not Use")]
        public string bared { get; set; }

        [Display(Name = "Availability")]
        public bool IsAvailable { get; set; }

        [Display(Name = "Date Joined")]
        [DataType(DataType.Date)]// but IT DOT NOT SUPPORT IE and Firefox
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}", ApplyFormatInEditMode = true)]
        public DateTime? StartDate { get; set; }

        [Display(Name = "Profile Picture")]
        public string Photo { get; set; }

        [Display(Name = "Next of Kin")]
        public string NextOfKin { get; set; }

        [Display(Name = "Food alergy")]
        public string Alergy { get; set; }

        [Display(Name = "Notes")]
        public string Note { get; set; }

        [Display(Name = "Post nominals")]
        public string PostNominals { get; set; }
    }
}