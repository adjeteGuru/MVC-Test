using MVC_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Test.Repository
{
    public partial class Repository
    {

        public IQueryable<Client> Clients
        {
            get { return context.Clients; }
        }

        public bool CreateClients(Client instance)
        {
            if (instance.Id == 0)
            {
                context.Clients.Add(instance);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateClients(Client instance)
        {
            var cache = context.Clients.FirstOrDefault(o => o.Id == instance.Id);
            if (cache != null)
            {
                context.Entry(cache).CurrentValues.SetValues(instance);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool RemoveClients(int id)
        {
            var instance = context.Clients.FirstOrDefault(o => o.Id == id);
            if (instance != null)
            {
                context.Clients.Remove(instance);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}