using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Test.Metadata
{
    public class BookingType
    {
        [Key]
        [Required]
        [MaxLength(10), MinLength(2)]
        public string BookingTypeID { get; set; }
    }
}