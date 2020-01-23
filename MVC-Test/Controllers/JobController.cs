using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_Test;
using MVC_Test.Models;
using MVC_Test.ViewModels;

namespace MVC_Test.Controllers
{
    public class JobController : Controller
    {
        private CloudbassContext db = new CloudbassContext();

        // GET: Job
        public ActionResult Index()
        {
            var jobs = db.Jobs.Include(j => j.Client);
            return View(jobs.ToList());
        }

        // GET: Job/Details/5
        public ActionResult Details(string id)
        {
            //IF NULL
            if (id == null && id != string.Empty)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //IF NOT NULL

            //THEN  RETURN THE FIRST INSTANCE OF THE JOBLIST (from dataset table)
            // BEFORE HAND, CREATE ON THE FLY X.Id=1 WITHOUT HAVING TO GO THROUGH THE PROSESS "X = NEW PRODUCT" BEFORE RETURN IT
            // AS THE FIRST INSTANCE OF THE OBJECT IN THE JOBLIST  

            var selectedJob = db.Jobs.First(x => x.Id == id);

            //IF NULL
            if (selectedJob == null)
            {
                return HttpNotFound();
            }

            //show 
            db.Schedules.ToList().Select(sc => new Schedule
            {
                Id = sc.Id,
                text = sc.text,
                start_date = sc.start_date,
                end_date = sc.end_date,
                SchType = sc.SchType
            });


            JobScheduleRoleViewModel viewModel = new JobScheduleRoleViewModel()
            {

                
                Job = selectedJob
                
            };

            return View(viewModel);
        }

        // GET: Job/Create
        public ActionResult Create()
        {
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name");
            return View();
        }

        // POST: Job/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,text,Description,Location,DateCreated,start_date,TXDate,end_date,Coordinator,CommercialLead,ClientId,Status")] Job job)
        {
            if (ModelState.IsValid)
            {
                db.Jobs.Add(job);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name", job.ClientId);
            return View(job);
        }

        // GET: Job/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name", job.ClientId);
            return View(job);
        }

        // POST: Job/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,text,Description,Location,DateCreated,start_date,TXDate,end_date,Coordinator,CommercialLead,ClientId,Status")] Job job)
        {
            if (ModelState.IsValid)
            {
                db.Entry(job).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name", job.ClientId);
            return View(job);
        }

        // GET: Job/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: Job/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Job job = db.Jobs.Find(id);
            db.Jobs.Remove(job);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
