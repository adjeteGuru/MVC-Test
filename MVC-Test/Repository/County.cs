using MVC_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Test.Repository
{
    public partial class Repository
    {
        public IQueryable<County> Counties
        {
            get { return context.Counties; }
        }

        public bool CreateCounties(County instance)
        {
            if (instance.Id ==0)
            {
                context.Counties.Add(instance);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateCounties(County instance)
        {
            var cache = context.Counties.FirstOrDefault(o => o.Id == instance.Id);
            if (cache != null)
            {
                context.Entry(cache).CurrentValues.SetValues(instance);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool RemoveCounties(int id)
        {
            var instance = context.Counties.FirstOrDefault(o => o.Id == id);
            if (instance != null)
            {
                context.Counties.Remove(instance);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}