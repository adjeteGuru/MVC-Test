using MVC_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Test.Repository
{
    public partial class Repository
    {
        public IQueryable<Crew> Crews
        {
            get { return context.Crews; }
        }

        public bool CreateCrews(Crew instance)
        {
            if (instance.Id == 0)
            {
                context.Crews.Add(instance);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateCrews(Crew instance)
        {
            var cache = context.Crews.FirstOrDefault(o => o.Id == instance.Id);
            if (cache != null)
            {
                context.Entry(cache).CurrentValues.SetValues(instance);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool RemoveCrews(int id)
        {
            var instance = context.Crews.FirstOrDefault(o => o.Id == id);
            if (instance != null)
            {
                context.Crews.Remove(instance);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}