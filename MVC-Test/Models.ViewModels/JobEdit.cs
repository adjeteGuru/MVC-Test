using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Test.Models.ViewModels
{
    public class JobEdit
    {
        [Display(Name = "Job ID")]
        public string JobId { get; set; }

        [Display(Name = "Reference")]
        public string JobRef { get; set; }

        [Display(Name = "Title")]
        public string text { get; set; }

        [Display(Name = "Desciption")]
        public string Description { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        [Display(Name = "Date created")]
        public DateTime? DateCreated { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        [Display(Name = "Start date")]
        public DateTime? start_date { get; set; }

        [DataType(DataType.Date)]
       [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Transmission")]
        public DateTime? TXDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        [Display(Name = "End date")]
        public DateTime? end_date { get; set; }

        [Display(Name = "Coordinator")]
        public string Coordinator { get; set; }

        [Display(Name = "Commercial Lead")]
        public string CommercialLead { get; set; }


        [Display(Name = "Client")]
        public string SelectedClientId { get; set; }
        public IEnumerable<SelectListItem> Clients { get; set; }

        public Status Status { get; set; }

    }
}