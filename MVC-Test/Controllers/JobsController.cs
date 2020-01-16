using MVC_Test.Repository;
using MVC_Test.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Test.DAL;

namespace MVC_Test.Controllers
{
    public class JobsController : Controller
    {
        // GET: Jobs
        public ActionResult Index()
        {
            var repo = new JobsRepository();
            var jobList = repo.GetJobs();
            return View(jobList);
        }

        //[HttpGet]
        //public ActionResult GetClients(int? id)
        //{
        //    if (id!= null)
        //    {
        //        var repo = new ClientsRepository();

        //        IEnumerable<SelectListItem> clients = repo.GetClients();
        //        return Json(clients, JsonRequestBehavior.AllowGet);
        //    }
        //    return null;
        //}


        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
           
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            var repo = new JobsRepository();
            var job = repo.CreateJob();
            return View(job);
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id, Name, SelectedClientId, Location, Coordinator,StartDate, TXDate,EndDate, CommercialLead, Status")] JobEditViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var repo = new JobsRepository();
                    bool saved = repo.SaveJob(model);
                    if (saved)
                    {
                        return RedirectToAction("Index");
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}