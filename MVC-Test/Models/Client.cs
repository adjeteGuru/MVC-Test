using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Test.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Tel { get; set; }
        public string Email { get; set; }
        public string ToContact { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Job> Jobs { get; set;}
    }
}