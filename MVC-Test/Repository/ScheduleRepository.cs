//using MVC_Test.DataAccessLayer;
using MVC_Test.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_Test.Repository
{
    public class ScheduleRepository
    {
        //public IEnumerable <JobSchedulesListViewModel> GetJobSchedulesDisplay(string id)
        //{

        public JobSchedulesListViewModel GetJobSchedulesDisplay(string id)
        {


            if (id != null && id != string.Empty)
         {
            
             using (var context = new CloudbassContext())
            {
                    var jobRepo = new JobsRepository();

                    var job = jobRepo.GetJob(id);

                 if (job !=null)
                    {
                        //var jobSchedulesListVm = (from p in context.JobSchedulesListViewModels
                        //                              //join f in context.JobEditViewModel
                        //                              //on p.Id equals f.Id
                        //                          select new
                        //                          {
                        //                              Id = job.Id,
                        //                              Name = job.text,
                        //                              DateCreated = job.DateCreated,
                        //                              Location = job.Location,
                        //                              Coordinator = job.Coordinator,
                        //                              ClientName = context.Clients.Find(job.ClientId).Name,
                        //                              StartDate = job.start_date,
                        //                              TXDate = job.TXDate,
                        //                              EndDate = job.end_date,
                        //                              CommercialLead = job.CommercialLead,
                        //                              Status = job.Status

                        //                          }).ToList()

                        //                          .Select(sc => new ScheduleDisplayViewModel()
                        //                          {
                        //                              JobId = sc.Id,
                        //                              //Id = sc.Id,
                        //                              //SchType = sc.,

                        //                              text = sc.Name,
                        //                              start_date = sc.StartDate,
                        //                              end_date = sc.EndDate,
                        //                          });

                        //return job;

                        var jobSchedulesListVm = new JobSchedulesListViewModel()
                        {
                            Id = job.Id,
                            text = job.text,
                            DateCreated = job.DateCreated,
                            Location = job.Location,
                            Coordinator = job.Coordinator,
                            ClientName = context.Clients.Find(job.ClientId).Name,
                            start_date = job.start_date,
                            TXDate = job.TXDate,
                            end_date = job.end_date,
                            CommercialLead = job.CommercialLead,
                            Status = job.Status
                        };

                        List<ScheduleDisplayViewModel> scheduleList = context.Schedules
                        //var scheduleList = new List<ScheduleDisplayViewModel>()
                            .Where(sc => sc.JobId == id)
                            .OrderBy(sc => sc.start_date)
                            .Select(sc =>
                            new ScheduleDisplayViewModel()
                            {
                                JobId = sc.JobId,
                                Id = sc.Id,
                                SchType = sc.SchType,

                                text = sc.text,
                                start_date = sc.start_date,
                                end_date = sc.end_date,



                            }).AsNoTracking().ToList();




                        jobSchedulesListVm.Schedules = scheduleList;
                        return jobSchedulesListVm;
                    }                      
                
             }



             
         }
            return null;
        }



        public void SaveSchedules(List<ScheduleDisplayViewModel> schedules)
        {
            if (schedules != null)
            {
                using (var context = new CloudbassContext())
                {
                    foreach (var schedule in schedules)
                    {
                        var record = context.Schedules.Find(schedule.Id);
                        if (schedule!=null)
                        {
                            record.text = schedule.text;
                        }
                    }

                    context.SaveChanges();

                }
            }

           
        }


    }
}