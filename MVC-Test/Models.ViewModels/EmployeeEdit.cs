using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Test.Models.ViewModels
{
    public class EmployeeEdit
    {
        public int Id { get; set; }
        public string fullName { get; set; }

        public string mobile { get; set; }
        public string email { get; set; }

        public Category Category { get; set; }
        public int countyId { get; set; }
        public string bared { get; set; }

        public bool isAvailable { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime? start_date { get; set; }
        public string photo { get; set; }
        public string nextOfKin { get; set; }
        public string alergy { get; set; }
        public string note { get; set; }
        public string postNominals { get; set; }

    }
}