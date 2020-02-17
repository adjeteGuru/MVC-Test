﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Test.Models.ViewModels
{
    public class Jobs
    {
        [Display(Name = "Job Number")]
        public Guid JobId { get; set; }


        [Display(Name = "Job Reference")]
        public string JobRef { get; set; }
        public string text { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }

        [DataType(DataType.Date)]
      //  [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateCreated { get; set; }

        [DataType(DataType.Date)]
       // [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? start_date { get; set; }

        [DataType(DataType.Date)]
      //  [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? TXDate { get; set; }

        [DataType(DataType.Date)]
       // [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? end_date { get; set; }
        public string Coordinator { get; set; }
        
        public string CommercialLead { get; set; }
       
        
        [Display(Name = "Client")]
        public string Client { get; set; }

        public Status Status { get; set; }


    }
}