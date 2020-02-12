using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Test.Repositories
{
    public class ClientRepository
    {
        public IEnumerable<SelectListItem> GetClients()
        {

            using (var context = new CloudbassContext())
            {
                List<SelectListItem> clients = context.Clients.AsNoTracking()
                    .OrderBy(cl => cl.name)
                    .Select(cl =>
                    new SelectListItem
                    {
                        Value = cl.Id.ToString(),
                        Text = cl.name
                    }
                    ).ToList();

                var clienttip = new SelectListItem()
                {
                    Value = null,
                    Text = "---select client---"
                };
                clients.Insert(0, clienttip);
                return new SelectList(clients, "Value", "Text");
            }
        }
    }
}