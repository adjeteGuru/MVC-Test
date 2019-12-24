using MVC_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Test.ViewModels
{
    public class JobVM
    {
        public string Name { get; set; }
        public int ClientId { get; set; }
        public string Coordinator { get; set; }
        public Status Status { get; set; }
        public DateTime? DateCreated { get; set; }
        public string CommercialLead { get; set; }


        public string JobId { get; set; }
        public string text { get; set; }

        public DateTime? start_date { get; set; }
        public DateTime? end_date { get; set; }
        public SchType SchType { get; set; }
    }
}