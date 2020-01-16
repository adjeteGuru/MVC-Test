using MVC_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Test.Repository
{
    public partial class Repository
    {
        public IQueryable<Role> Roles
        {
            get { return context.Roles; }
        }

        public bool CreateRoles(Role instance)
        {
            if (instance.Id == 0)
            {
                context.Roles.Add(instance);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateRoles(Role instance)
        {
            var cache = context.Roles.FirstOrDefault(o => o.Id == instance.Id);
            if (cache != null)
            {
                context.Entry(cache).CurrentValues.SetValues(instance);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool RemoveRoles(int id)
        {
            var instance = context.Roles.FirstOrDefault(o => o.Id == id);
            if (instance != null)
            {
                context.Roles.Remove(instance);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}