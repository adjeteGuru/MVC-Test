﻿
using MVC_Test.Metadata;
using MVC_Test.Models.ViewModels;
using MVC_Test.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVC_Test.Controllers
{
    public class JobsController : Controller
    {
        // GET: Jobs
        public ActionResult Index()
        {
            var repo = new JobRepository();
            var jobList = repo.GetJobs();
            return View(jobList);
        }

        [HttpGet]
        public ActionResult GetClients(int? id)
        {
            if (id != null)
            {
                var repo = new ClientRepository();

                IEnumerable<SelectListItem> clients = repo.GetClients();
                return Json(clients, JsonRequestBehavior.AllowGet);
            }
            return null;
        }



        // GET: Job/Details/5
        public ActionResult Details(int id)
        {
            return View();

        }

        // GET: Job/Create
        public ActionResult Create()
        {
            var repo = new JobRepository();
            var job = repo.CreateJob();
            return View(job);
        }

        // POST: Job/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "JobId, text,Description, SelectedClientId, DateCreated, Location, Coordinator,start_date, TXDate, end_date, CommercialLead, ")] JobEdit model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var repo = new JobRepository();
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


        // GET: Job/Edit/5

        public ActionResult Edit(string id)
        {
            if (!String.IsNullOrWhiteSpace(id))
            {
                bool isGuid = Guid.TryParse(id, out Guid jobId);
                if (isGuid && jobId != Guid.Empty)
                {
                    return View();
                }
            }

            

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

        }

        [ChildActionOnly]
        public ActionResult EditJobPartial(string id)
        {
            if (!String.IsNullOrWhiteSpace(id))
            {
                bool isGuid = Guid.TryParse(id, out Guid jobId);
                if (isGuid && jobId != Guid.Empty)
                {
                    var repo = new JobRepository();
                    var model = repo.GetJob(jobId);

                    return View(model);
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        // POST: Customer/Edit/5
        [ValidateAntiForgeryToken]
        public ActionResult EditJobPartial(JobEdit model)
        {
            if (ModelState.IsValid)
            {
                var repo = new JobRepository();
                bool saved = repo.SaveJob(model);
                if (saved)
                {
                    bool isGuid = Guid.TryParse(model.JobId, out Guid jobId);
                    if (isGuid)
                    {
                        var modelUpdate = repo.GetJob(jobId);
                        return PartialView(modelUpdate);
                    }
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }


        [ChildActionOnly]
        public ActionResult BookingTypePartial(string id)
        {
            if (!String.IsNullOrWhiteSpace(id))
            {
                bool isGuid = Guid.TryParse(id, out Guid jobId);
                if (isGuid && jobId != Guid.Empty)
                {
                    var repo = new MetadataRepository();
                    var model = new Models.ViewModels.BookingType()
                    {
                        JobId = id,
                        BookingTypes = repo.GetBookingTypes()
                    };
                    return PartialView("BookingTypePartial", model);
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BookingTypePartial(Models.ViewModels.BookingType model)
        {
            if (ModelState.IsValid && !String.IsNullOrWhiteSpace(model.JobId))
            {
                switch (model.SelectedBookingType)
                {
                    case "Schedule":
                        var scheduleModel = new Schedule()
                        {
                            JobId = model.JobId
                        };
                        return PartialView("CreateSchedulePartial", scheduleModel);

                    case "Crew":
                        var crewModel = new Crew()
                        {
                            JobId = model.JobId
                        };

                        return PartialView("CreateCrewPartial", crewModel);

                    case "BookinFleet":
                        var fleetModel = new BookingFleet()
                        {
                            JobId = model.JobId
                        };
                        //var fleetTypeRepo = new FleetTypeRepository();
                        //fleetModel. = fleetTypeRepo.GetFleetTypes();
                        //var regionsRepo = new RegionsRepository();
                        //postalAddressModel.Regions = regionsRepo.GetRegions();
                        return PartialView("CreateBookingFleetPartial", fleetModel);

                    case "BookingHotel":
                        var hotelModel = new BookingHotel()
                        {
                            JobId = model.JobId
                        };
                        //var countriesRepo = new CountriesRepository();
                        //postalAddressModel.Countries = countriesRepo.GetCountries();
                        //var regionsRepo = new RegionsRepository();
                        //postalAddressModel.Regions = regionsRepo.GetRegions();
                        return PartialView("CreateBookingHotelPartial", hotelModel);

                    case "BookingKit":
                        var kitModel = new BookingKit()
                        {
                            JobId = model.JobId
                        };
                        //var countriesRepo = new CountriesRepository();
                        //postalAddressModel.Countries = countriesRepo.GetCountries();
                        //var regionsRepo = new RegionsRepository();
                        //postalAddressModel.Regions = regionsRepo.GetRegions();
                        return PartialView("CreateBookingKitPartial", kitModel);


                    case "BookingEquipment":
                        var equipmentModel = new BookingEquipment()
                        {
                            JobId = model.JobId
                        };
                        //var countriesRepo = new CountriesRepository();
                        //postalAddressModel.Countries = countriesRepo.GetCountries();
                        //var regionsRepo = new RegionsRepository();
                        //postalAddressModel.Regions = regionsRepo.GetRegions();
                        return PartialView("CreateBookingPartial", equipmentModel);

                    default:
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }


        // NEW STARTED

        [HttpPost] //THIS IS has worked
        [ValidateAntiForgeryToken]
        public ActionResult CreateSchedulePartial(ScheduleEdit model)
        {
            if (ModelState.IsValid)
            {
                var repo = new JobRepository();
                var updatedModel = repo.SaveSchedule(model);
                if (updatedModel != null)
                {
                    return RedirectToAction("Edit", new { id = model.JobId });
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }



        // GET: job/Delete/5
        public ActionResult Delete(string id)
        {
            return View();
        }

        // POST: job/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
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