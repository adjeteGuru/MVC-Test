using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Test.Models.ViewModels
{
    public class Jobs
    {
        [Display(Name = "Job ID")]
        public Guid JobId { get; set; }


        [Display(Name = "Reference")]
        public string JobRef { get; set; }

        [Display(Name = "Title")]
        public string text { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; }

        [Display(Name = "Date created")]

        [DataType(DataType.Date)]
       [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateCreated { get; set; }


        [Display(Name = "Start date")]

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? start_date { get; set; }


        [Display(Name = "Transmission")]

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? TXDate { get; set; }


        [Display(Name = "End date")]

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? end_date { get; set; }


        [Display(Name = " Coordinator")]
        public string Coordinator { get; set; }


        [Display(Name = " Commercial Lead")]
        public string CommercialLead { get; set; }
       
        
        [Display(Name = "Client")]
        public string Client { get; set; }

        public Status Status { get; set; }


    }
}