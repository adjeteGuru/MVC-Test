﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Test.Models.ViewModels
{
    public class JobEdit
    {
        [Display(Name = "Job Number")]
        public string JobId { get; set; }
        public string text { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? start_date { get; set; }
        public DateTime? TXDate { get; set; }
        public DateTime? end_date { get; set; }
        public string Coordinator { get; set; }

        public string CommercialLead { get; set; }


        [Display(Name = "Client")]
        public string SelectedClientId { get; set; }
        public IEnumerable<SelectListItem> Clients { get; set; }

    }
}