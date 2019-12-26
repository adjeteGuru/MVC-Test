using MVC_Test.DataAccessLayer;
using MVC_Test.Models;
using MVC_Test.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Test.Controllers
{
    public class JobDetailsController : Controller
    {
        [AcceptVerbs(HttpVerbs.Get)]
        // GET: JobDetails
        public ActionResult Index()
        {
            CloudbassContext context = new CloudbassContext(); //dbContext class



            List<JobVM> JobVMList = new List<JobVM>(); //to hold list of Job and Schedule details

            var jobList = (from jo in context.Jobs
                           join sc in context.Schedules on jo.Id equals sc.JobId
                           select new { jo.Name, jo.ClientId, jo.DateCreated, jo.Coordinator, jo.CommercialLead, jo.Status , sc.text, sc.SchType,  sc.start_date, sc.end_date}).ToList();
            //query getting data from database from joining two tables and storing data in jobList
            foreach (var data in jobList)
            {
                JobVM objcvm = new JobVM(); //ViewModel
                objcvm.Name = data.Name;
                objcvm.ClientId = data.ClientId;
                objcvm.DateCreated = data.DateCreated;
                objcvm.CommercialLead = data.CommercialLead;
                objcvm.Coordinator = data.Coordinator;
                objcvm.Status = data.Status;
                objcvm.text = data.text;
                objcvm.SchType = data.SchType;
                objcvm.start_date = data.start_date;
                objcvm.end_date = data.end_date;
                               
            }

            //Using foreach loop fill data from jobList to list<JobVM>
            return View(JobVMList);
        }
    }
}