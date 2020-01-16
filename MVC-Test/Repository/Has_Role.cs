using MVC_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Test.Repository
{
    public partial class Repository
    {
        public IQueryable<Has_Role> Has_Roles
        {
            get { return context.Has_Roles; }
        }

        public bool CreateHas_Roles(Has_Role instance)
        {
            if (instance.Id == 0)
            {
                context.Has_Roles.Add(instance);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateHas_Roles(Has_Role instance)
        {
            var cache = context.Has_Roles.FirstOrDefault(o => o.Id == instance.Id);
            if (cache != null)
            {
                context.Entry(cache).CurrentValues.SetValues(instance);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool RemoveHas_Roles(int id)
        {
            var instance = context.Has_Roles.FirstOrDefault(o => o.Id == id);
            if (instance != null)
            {
                context.Has_Roles.Remove(instance);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}