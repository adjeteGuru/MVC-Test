using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Test.Models.ViewModels
{
    public class Has_Role
    {
        public int Id { get; set; }
        public int employeeId { get; set; }
        public int roleId { get; set; }
        public DateTime? start_date { get; set; }
        public DateTime? end_date { get; set; }
        public double totalDays { get; set; }
        public Decimal rate { get; set; }
       


    }
}