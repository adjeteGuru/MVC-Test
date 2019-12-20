using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Test.Models
{
    public class Role
    {

        public  int Id { get; set; }
        public  string Name { get; set; }
        public virtual ICollection<Has_Role> Has_Roles { get; set; }
    }
}