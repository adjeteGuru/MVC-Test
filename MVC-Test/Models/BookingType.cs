using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Test.Models
{
    public class BookingType
    {

        [Key]
        [Required]
        [MaxLength(10), MinLength(2)]
        public string BookingTypeID { get; set; }
       // public IEnumerable<SelectListItem> BookingTypes { get; internal set; }
    }
}