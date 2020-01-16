using MVC_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Test.Repository
{
    public partial class Repository
    {

        public IQueryable<Job> Jobs
        {
            get { return context.Jobs; }
        }

        public bool CreateJobs(Job instance)
        {
            if/*(instance.Id != string.Empty)*/ (instance.Id == "")
            {
                context.Jobs.Add(instance);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateClients(Job instance)
        {
            var cache = context.Jobs.FirstOrDefault(o => o.Id == instance.Id);
            if (cache != null)
            {
                context.Entry(cache).CurrentValues.SetValues(instance);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool RemoveJobs(string id)
        {
            var instance = context.Jobs.FirstOrDefault(o => o.Id == id);
            if (instance != null)
            {
                context.Jobs.Remove(instance);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}