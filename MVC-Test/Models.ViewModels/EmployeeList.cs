using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Test.Models.ViewModels
{
    public class EmployeeList
    {
        public int Id { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}