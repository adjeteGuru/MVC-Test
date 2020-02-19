using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Test.Models.ViewModels
{
    public class ComboList
    {
        [StringLength(38)]
        public string JobId { get; set; }

        public ICollection<ComboClassesViewModel> ComboClasses { get; set; }
    }
}