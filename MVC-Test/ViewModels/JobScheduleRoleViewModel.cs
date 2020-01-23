using MVC_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Test.ViewModels
{
    public class JobScheduleRoleViewModel
    {
        public Job Job { get; set; }
        public Schedule Schedule { get; set; }
        public Has_Role Has_Role { get; set; }
        public Crew Crew { get; set; }
    }
}