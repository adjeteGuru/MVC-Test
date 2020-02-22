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
            List<Jobs> OrderAndCustomerList = db.Jobs.ToList();
            return View(OrderAndCustomerList);
        }


        public ActionResult SaveOrder(string text, String location, Order[] order)
        {
            string result = "Error! Order Is Not Complete!";
            if (text != null && location != null && order != null)
            {
                var jobId = Guid.NewGuid();
                Jobs model = new Jobs();
                model.JobId = jobId;
                model.text = text;
                model.Location = location;
                model.DateCreated = DateTime.Now;
                model.start_date = new DateTime(12 / 03 / 2020);
                model.TXDate = new DateTime(13 / 03 / 2020);
                model.end_date = new DateTime(14 / 03 / 2020);
               // model.Coordinator = coo;
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
                result = "Success! Order Is Complete!";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}