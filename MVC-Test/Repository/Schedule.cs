using MVC_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Test.Repository
{
    public partial class Repository
    {
        public CloudbassContext context { get; set; }

        public IQueryable<Schedule> Schedules
        {
            get { return context.Schedules; }
        }

        public bool CreateSchedules(Schedule instance)
        {
            if (instance.Id == 0)
            {
                context.Schedules.Add(instance);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateSchedules(Schedule instance)
        {
            var cache = context.Schedules.FirstOrDefault(o => o.Id == instance.Id);
            if (cache != null)
            {
                context.Entry(cache).CurrentValues.SetValues(instance);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool RemoveSchedules(int id)
        {
            var instance = context.Schedules.FirstOrDefault(o => o.Id == id);
            if (instance != null)
            {
                context.Schedules.Remove(instance);
                context.SaveChanges();
                return true;
            }
            return false;
        }

    }
}