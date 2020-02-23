using MVC_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Test.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Orders
        CloudbassContext db = new CloudbassContext();

        public ActionResult Index()
        {
            List<Jobs> OrderAndJobList = db.Jobs.ToList();
            return View(OrderAndJobList);
        }


        public ActionResult SaveOrder(string text, String location,/* string client,*/ string coordinator, Order[] order)
        {
            string result = "Error! Booking Is Not Complete!";
            if (text != null && location != null/* && client != null*/ && coordinator != null && order != null)
            {
                var jobId = Guid.NewGuid();
                Jobs model = new Jobs();
                //var model = db.Jobs.First(x => x.JobId == modelModified.JobId);

                model.JobId = jobId;
                model.text = text;
                model.Location = location;
                model.DateCreated = DateTime.Now;
               // model.ClientId = client;
                //model.start_date = 
                //model.TXDate = new DateTime();
                //model.end_date = new DateTime();
                 model.Coordinator = coordinator;
                // model.CommercialLead = address;
                db.Jobs.Add(model);

                foreach (var item in order)
                {
                    var orderId = Guid.NewGuid();
                    Order O = new Order();
                    O.OrderId = orderId;
                    O.ServiceName = item.ServiceName;
                    O.Quantity = item.Quantity;
                    O.Rate = item.Rate;
                    O.Amount = item.Amount;
                    O.JobId = jobId;
                    db.Orders.Add(O);
                }
                db.SaveChanges();

                result = "Success! Booking Is Complete!";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //get client details
        public JsonResult getClient()
        {
            List<Client> clients = new List<Client>();

            //using (CloudbassContext dc = new CloudbassContext())
            //{
            //    clients = dc.Clients.OrderBy(x => x.name).ToList();
            //}

            using (CloudbassContext dc = new CloudbassContext())
            {
                clients = dc.Clients.OrderBy(x => x.name).ToList();
            }


            return new JsonResult { Data = clients, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}