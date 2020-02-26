using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Test.Models.ViewModels
{
    public class RoleList
    {
       
        public int Id { get; set; }

        public ICollection<Role> Roles { get; set; }
    }
}