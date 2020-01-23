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
    public class ScheduleController : Controller
    {
        private CloudbassContext db = new CloudbassContext();

        // GET: Schedule
        public ActionResult Index()
        {
            var schedules = db.Schedules.Include(s => s.Job);
            return View(schedules.ToList());
        }

        // GET: Schedule/Details/5
        public ActionResult Details(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Schedule schedule = db.Schedules.Find(id);
            //if (schedule == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(schedule);

            //IF NULL
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //IF NOT NULL

            //THEN  RETURN THE FIRST INSTANCE OF THE JOBLIST (from dataset table)
            // BEFORE HAND, CREATE ON THE FLY X.Id=1 WITHOUT HAVING TO GO THROUGH THE PROSESS "X = NEW PRODUCT" BEFORE RETURN IT
            // AS THE FIRST INSTANCE OF THE OBJECT IN THE JOBLIST  

            var selectedSchedule = db.Schedules.First(x => x.Id == id);

            //IF NULL
            if (selectedSchedule == null)
            {
                return HttpNotFound();
            }

            //IF NOT NULL THEN

            var job = new Job()

            {
                Id = selectedSchedule.Id,
                ClientId = selectedJob.ClientId,
                text = selectedJob.text,
                Location = selectedJob.Location,
                TXDate = selectedJob.TXDate,
                Coordinator = selectedJob.Coordinator

            };

            JobScheduleRoleViewModel viewModel = new JobScheduleRoleViewModel()
            {
                Job = job,
                //Schedule = schedule,

            }

            return View(selectedSchedule);
        }
    }

        // GET: Schedule/Create
        public ActionResult Create()
        {
            ViewBag.JobId = new SelectList(db.Jobs, "Id", "text");
            return View();
        }

        // POST: Schedule/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,text,start_date,end_date,SchType,JobId")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                db.Schedules.Add(schedule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.JobId = new SelectList(db.Jobs, "Id", "text", schedule.JobId);
            return View(schedule);
        }

        // GET: Schedule/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule schedule = db.Schedules.Find(id);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            ViewBag.JobId = new SelectList(db.Jobs, "Id", "text", schedule.JobId);
            return View(schedule);
        }

        // POST: Schedule/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,text,start_date,end_date,SchType,JobId")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(schedule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.JobId = new SelectList(db.Jobs, "Id", "text", schedule.JobId);
            return View(schedule);
        }

        // GET: Schedule/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule schedule = db.Schedules.Find(id);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            return View(schedule);
        }

        // POST: Schedule/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Schedule schedule = db.Schedules.Find(id);
            db.Schedules.Remove(schedule);
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
