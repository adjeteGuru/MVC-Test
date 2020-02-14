using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Test.Controllers
{
    public class JobsBISController : Controller
    {
        // GET: JobsBIS
        public class JobsController : Controller
        {
            // GET: Jobs
            public JsonResult Get(int? page, int? limit, string sortBy, string direction, string Jobsname, string clientname, string location)
            {
                List<Models.ViewModels.Jobs> records;
                int total;
                using (CloudbassContext context = new CloudbassContext())
                {
                    var query = context.Jobs.Select(p => new Models.ViewModels.Jobs
                    {
                        JobId = p.JobId,

                        JobRef = p.JobRef,
                        text = p.text,

                        Description = p.Description,
                        Location = p.Location,
                        start_date = p.start_date,
                        DateCreated = p.DateCreated,
                        end_date = p.end_date,
                        TXDate = p.TXDate,
                        Coordinator = p.Coordinator,
                        CommercialLead = p.CommercialLead,
                        Client = p.ClientId,


                        Status = p.Status


                    });

                    if (!string.IsNullOrWhiteSpace(Jobsname))
                    {
                        query = query.Where(q => q.text.Contains(Jobsname));
                    }

                    if (!string.IsNullOrWhiteSpace(location))
                    {
                        query = query.Where(q => q.Location.Contains(location));
                    }

                    //if (!string.IsNullOrWhiteSpace(clientname))
                    //{
                    //    query = query.Where(q => q.ClientName.Contains(clientname));
                    //}




                    if (!string.IsNullOrEmpty(sortBy) && !string.IsNullOrEmpty(direction))
                    {
                        if (direction.Trim().ToLower() == "asc")
                        {
                            switch (sortBy.Trim().ToLower())
                            {
                                case "Jobsname":
                                    query = query.OrderBy(q => q.text);
                                    break;
                                case "location":
                                    query = query.OrderBy(q => q.Location);
                                    break;
                                    //case "clientname":
                                    //    query = query.OrderBy(q => q.ClientName);
                                    //    break;

                            }
                        }
                        else
                        {
                            switch (sortBy.Trim().ToLower())
                            {
                                case "Jobsname":
                                    query = query.OrderByDescending(q => q.text);
                                    break;
                                case "location":
                                    query = query.OrderByDescending(q => q.Location);
                                    break;
                                    //case "clientname":
                                    //    query = query.OrderByDescending(q => q.ClientName);
                                    //    break;

                            }
                        }
                    }
                    else
                    {
                        query = query.OrderBy(q => q.TXDate);
                    }

                    total = query.Count();
                    if (page.HasValue && limit.HasValue)
                    {
                        int start = (page.Value - 1) * limit.Value;
                        records = query.Skip(start).Take(limit.Value).ToList();
                    }
                    else
                    {
                        records = query.ToList();
                    }
                }

                return this.Json(new { records, total }, JsonRequestBehavior.AllowGet);
            }

            [HttpPost]
            public JsonResult Save(Models.ViewModels.Jobs record)
            {
                Models.Jobs entity;
                using (CloudbassContext context = new CloudbassContext())
                {
                    if (record.JobId != null)
                    {
                        entity = context.Jobs.First(p => p.JobId == record.JobId);
                        entity.text = record.text;
                        entity.Description = record.Description;
                        entity.Location = record.Location;
                        entity.ClientId = record.Client;
                        //entity.Country = context.Locations.FirstOrDefault(l => l.ID == record.CountryID);
                        entity.Status = record.Status;
                        entity.DateCreated = record.DateCreated;
                        entity.TXDate = record.TXDate;
                        entity.start_date = record.start_date;
                        entity.end_date = record.end_date;
                        entity.Coordinator = record.Coordinator;
                        entity.CommercialLead = record.CommercialLead;

                    }
                    else
                    {
                        context.Jobs.Add(new Models.Jobs
                        {
                            JobId = record.JobId,
                            text = record.text,

                            Description = record.Description,
                            Location = record.Location,
                            start_date = record.start_date,
                            DateCreated = record.DateCreated,
                            end_date = record.end_date,
                            TXDate = record.TXDate,
                            Coordinator = record.Coordinator,
                            CommercialLead = record.CommercialLead,
                            ClientId = record.Client,

                            // statusId = record.statusId,
                        });
                    }
                    context.SaveChanges();
                }
                return Json(new { result = true });
            }

            [HttpPost]
            public JsonResult Delete(string id)
            {
                using (CloudbassContext context = new CloudbassContext())
                {

                    Models.Jobs entity = context.Jobs.First(p => p.JobId.ToString() == id);
                    context.Jobs.Remove(entity);
                    context.SaveChanges();
                }
                return Json(new { result = true });
            }

            public JsonResult GetSchedules(string Id, int? page, int? limit)
            {
                List<Models.ViewModels.Schedule> records;
                int total;
                using (CloudbassContext context = new CloudbassContext())
                {
                    //TO GUID CONVERDSION
                    //var customerProfileGuid = new Guid(customerProfileId);
                    var query = context.Schedules.Where(pt => pt.JobId.ToString() == Id).Select(pt => new Models.ViewModels.Schedule
                    {
                        Id = pt.Id,
                        //JobsId = pt.JobsId,
                        //JobsName = pt.
                        text = pt.text,

                        // SchTypeId = pt.SchTypeId,
                        SchType = pt.SchType,
                        start_date = pt.start_date,
                        end_date = pt.end_date,
                        //statusId = pt.statusId,


                    });

                    total = query.Count();
                    if (page.HasValue && limit.HasValue)
                    {
                        int start = (page.Value - 1) * limit.Value;
                        records = query.OrderBy(pt => pt.start_date).Skip(start).Take(limit.Value).ToList();
                    }
                    else
                    {
                        records = query.ToList();
                    }
                }

                return this.Json(new { records, total }, JsonRequestBehavior.AllowGet);
            }

        }
    }
}