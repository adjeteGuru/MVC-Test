using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_Test.Models
{
    public enum Status
    {
        InQuotation, Active, Cancelled, Completed
    }
    public class Jobs
    {              
       
            [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Display(Name = "ID")]
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
        public DateTime? DateCreated { get; set; }

        [Display(Name = "Start date")]
        public DateTime? start_date { get; set; }

        [Display(Name = "Transmission")]
        public DateTime? TXDate { get; set; }

        [Display(Name = "End date")]
        public DateTime? end_date { get; set; }

        [Display(Name = "Coordinator")]
        public string Coordinator { get; set; }

        [Display(Name = "Commercial Lead")]
        public string CommercialLead { get; set; }

        [Display(Name = "Client ID")]
        public string ClientId { get; set; }

       

        public virtual Client Client { get; set; }

            public Status Status { get; set; }
            public ICollection<Crew> Crews { get; set; }
        
    }
}