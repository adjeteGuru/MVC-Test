using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_Test.DAL;
using MVC_Test.Models;
using MVC_Test.ViewModels;

namespace MVC_Test.Controllers
{
    public class Has_RoleController : Controller
    {
        private CloudbassContext db = new CloudbassContext();

        // GET: Has_Role
        public ActionResult Index()
        {
            var has_Roles = db.Has_Roles.Include(h => h.Employee).Include(h => h.Role);
            return View(has_Roles.ToList());
        }

        // GET: Has_Role/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    //Has_Role has_Role = db.Has_Roles.Find(id);
        //    Has_Role selectedHasRole = db.Has_Roles.First(x => x.Id == id);
        //    if (selectedHasRole == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    //create a job property as we set the object up

        //    var job = new Job()
        //    {
        //        Id = ,
        //        ClientId = ,
        //        text = ,
        //        Location = ,
        //        TXDate = ,
        //        Coordinator =
        //    };

        //    // var job = new Job(new CloudbassContext().Jobs.Select(x => new { x.Id, x.text, x.Location, x.start_date, x.end_date, x.Description, x.Client.Name }));
        //    //var job = new Job { Id = "cb14", text = "Question Time", Description = "Social political review", Location = "Scotland", Coordinator = "Jeph Brown", DateCreated = DateTime.Parse("2020-01-22"), start_date = DateTime.Parse("2020-02-01"), end_date = DateTime.Parse("2020-02-03"), Status = Status.Active, CommercialLead = "Francis Akai", ClientId = db.Clients.Find(3).Id }; 
        //    // var job = db.Jobs.ToList();

        //    // var job = new Job { Id = "cb13", text = "MUTV", Description = "under 21 league", Location = "Manchester Old traford", Coordinator = "Sir Bobby", DateCreated = DateTime.Parse("2019-12-10"), start_date = DateTime.Parse("2019-12-11"), end_date = DateTime.Parse("2019-12-16"), Status = Status.Active, CommercialLead = "Francis Akai", ClientId = db.Clients.Find(3).Id };
        //    //then hardcoding this object to hold the selectedHasRole and Job in it.
        //    JobScheduleRoleViewModel viewModel = new JobScheduleRoleViewModel()
        //    {

        //        Job = job,

        //        //Schedule = schedule,
        //        Has_Role = selectedHasRole
        //    };

        //    //passing the viewModel to the view
        //    return View(viewModel);
        //}

        // GET: Has_Role/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "FirstName");
            ViewBag.RoleId = new SelectList(db.Roles, "Id", "Name");
            return View();
        }

        // POST: Has_Role/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EmployeeId,RoleId,StartTime,EndTime")] Has_Role has_Role)
        {
            if (ModelState.IsValid)
            {
                db.Has_Roles.Add(has_Role);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "FirstName", has_Role.EmployeeId);
            ViewBag.RoleId = new SelectList(db.Roles, "Id", "Name", has_Role.RoleId);
            return View(has_Role);
        }

        // GET: Has_Role/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Has_Role has_Role = db.Has_Roles.Find(id);
            if (has_Role == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "FirstName", has_Role.EmployeeId);
            ViewBag.RoleId = new SelectList(db.Roles, "Id", "Name", has_Role.RoleId);
            return View(has_Role);
        }

        // POST: Has_Role/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EmployeeId,RoleId,StartTime,EndTime")] Has_Role has_Role)
        {
            if (ModelState.IsValid)
            {
                db.Entry(has_Role).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "FirstName", has_Role.EmployeeId);
            ViewBag.RoleId = new SelectList(db.Roles, "Id", "Name", has_Role.RoleId);
            return View(has_Role);
        }

        // GET: Has_Role/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Has_Role has_Role = db.Has_Roles.Find(id);
            if (has_Role == null)
            {
                return HttpNotFound();
            }
            return View(has_Role);
        }

        // POST: Has_Role/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Has_Role has_Role = db.Has_Roles.Find(id);
            db.Has_Roles.Remove(has_Role);
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
