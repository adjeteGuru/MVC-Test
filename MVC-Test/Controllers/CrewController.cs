using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_Test.DataAccessLayer;
using MVC_Test.Models;

namespace MVC_Test.Controllers
{
    public class CrewController : Controller
    {
        private CloudbassContext db = new CloudbassContext();

        // GET: Crew
        public ActionResult Index()
        {
            var crews = db.Crews.Include(c => c.Has_Role).Include(c => c.Schedule);
            return View(crews.ToList());
        }

        // GET: Crew/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crew crew = db.Crews.Find(id);
            if (crew == null)
            {
                return HttpNotFound();
            }
            return View(crew);
        }

        // GET: Crew/Create
        public ActionResult Create()
        {
            ViewBag.Has_RoleId = new SelectList(db.Has_Roles, "Id", "Id");
            ViewBag.ScheduleId = new SelectList(db.Schedules, "Id", "text");
            return View();
        }

        // POST: Crew/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ScheduleId,Has_RoleId,StartTime,EndTime,TotalHours,Cost")] Crew crew)
        {
            if (ModelState.IsValid)
            {
                db.Crews.Add(crew);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Has_RoleId = new SelectList(db.Has_Roles, "Id", "Id", crew.Has_RoleId);
            ViewBag.ScheduleId = new SelectList(db.Schedules, "Id", "text", crew.ScheduleId);
            return View(crew);
        }

        // GET: Crew/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crew crew = db.Crews.Find(id);
            if (crew == null)
            {
                return HttpNotFound();
            }
            ViewBag.Has_RoleId = new SelectList(db.Has_Roles, "Id", "Id", crew.Has_RoleId);
            ViewBag.ScheduleId = new SelectList(db.Schedules, "Id", "text", crew.ScheduleId);
            return View(crew);
        }

        // POST: Crew/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ScheduleId,Has_RoleId,StartTime,EndTime,TotalHours,Cost")] Crew crew)
        {
            if (ModelState.IsValid)
            {
                db.Entry(crew).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Has_RoleId = new SelectList(db.Has_Roles, "Id", "Id", crew.Has_RoleId);
            ViewBag.ScheduleId = new SelectList(db.Schedules, "Id", "text", crew.ScheduleId);
            return View(crew);
        }

        // GET: Crew/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crew crew = db.Crews.Find(id);
            if (crew == null)
            {
                return HttpNotFound();
            }
            return View(crew);
        }

        // POST: Crew/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Crew crew = db.Crews.Find(id);
            db.Crews.Remove(crew);
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
