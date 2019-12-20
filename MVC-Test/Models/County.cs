using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Test.Models
{
    public class County
    {

        public  int Id  { get; set; }
        public  string Name { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}