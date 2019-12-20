using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Test.Models
{
    public class Account
    {
        public  int Id { get; set; }
        public  string Email { get; set; }
        public  bool IsAdmin { get; set; }
        public  string ConfirmPassword { get; set; }
        public  bool Active { get; set; }
        public  string Code { get; set; }
    }
}