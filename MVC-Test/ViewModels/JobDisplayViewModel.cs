using MVC_Test.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Test.ViewModels
{
    public class JobDisplayViewModel
    {
        [Display(Name = "Job ID")]
        public string Id { get; set; }

        [Display(Name = "Job Name")]
        public string Name { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; }

        [Display(Name = "Date Created")]
        [DataType(DataType.Date)]// but IT DOT NOT SUPPORT IE and Firefox
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateCreated { get; set; }

        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]// but IT DOT NOT SUPPORT IE and Firefox
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}", ApplyFormatInEditMode = true)]
        public DateTime? StartDate { get; set; }

        [Display(Name = "TX Date")]
        [DataType(DataType.Date)]// but IT DOT NOT SUPPORT IE and Firefox
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}", ApplyFormatInEditMode = true)]
        public DateTime? TXDate { get; set; }

        [Display(Name = "End Date")]
        [DataType(DataType.Date)]// but IT DOT NOT SUPPORT IE and Firefox
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}", ApplyFormatInEditMode = true)]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Coordinator")]
        public string Coordinator { get; set; }

        [Display(Name = "Commercial Lead")]
        public string CommercialLead { get; set; }

        [Display(Name = "Client Name")]
        public string ClientName { get; set; }
 

        [Display(Name = "Status")]
        public Status Status { get; set; }

    }
}