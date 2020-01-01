using MVC_Test.Repository;
using MVC_Test.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVC_Test.Controllers
{
    public class JobVMController : Controller
    {
        // GET: JobVM
        public ActionResult Index(string id)
        {
            if (!String.IsNullOrWhiteSpace(id))
            {
                //if (Guid.TryParse(id, out Guid Id))
                //{
                var repo = new ScheduleRepository();
                var model = repo.GetJobSchedulesDisplay(id);
                return View(model);
                //}
            }

            if (id != null)
            {
                var repo = new ScheduleRepository();
                //var model = repo.GetJobSchedulesDisplay(Guid.Parse(id));

                var model = repo.GetJobSchedulesDisplay(id);
                return View(model);
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(JobSchedulesListViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Schedules != null)
                {
                    var repo = new ScheduleRepository();
                    repo.SaveSchedules(model.Schedules);
                }
                return View(model);
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }


    }
}