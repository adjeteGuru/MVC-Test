using MVC_Test.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Test.Repositories
{
    public class ComboRepository
    {

        //public ComboClassesViewModel GetComboDisplay(Guid id)
        //{


        //    if (id != Guid.Empty)
        //    {

        //        using (var context = new CloudbassContext())
        //        {
        //            var jobRepo = new JobRepository();

        //            var job = jobRepo.GetJob(id);

        //            if (job != null)
        //            {
        //                var jobComboListVm = new ComboClassesViewModel()
        //                {
        //                    JobId = job.JobId,
        //                    // Name = job.Name,
        //                    name = job.JobId,
        //                    DateCreated = job.DateCreated,
        //                    //Location = job.Location,
        //                    Coordinator = job.Coordinator,
        //                    ClientName = context.Clients.Find(job.ClientId).Name,
        //                    StartDate = job.start_date,
        //                    TXDate = job.TXDate,
        //                    EndDate = job.end_date,
        //                    CommercialLead = job.CommercialLead,
        //                    //Status = job.Status
        //                };

        //                List<ScheduleDisplayViewModel> scheduleList = context.Schedules.AsNoTracking()

        //                    .Where(sc => sc.JobId == id)
        //                    .OrderBy(sc => sc.start_date)
        //                    .Select(sc =>
        //                    new ScheduleDisplayViewModel
        //                    {
        //                        JobId = sc.JobId,
        //                        Id = sc.Id,
        //                        SchTypeName = sc.SchType.name,
        //                        //SchTypeId = sc.SchTypeId,
        //                        text = sc.text,
        //                        start_date = sc.start_date,
        //                        end_date = sc.end_date,


        //                    }).ToList();

        //                jobSchedulesListVm.Schedules = scheduleList;
        //                return jobSchedulesListVm;
        //            }

        //        }


        //    }
        //    return null;
        //}



        //public void SaveCombo(List<ScheduleDisplayViewModel> schedules)
        //{
        //    if (schedules != null)
        //    {
        //        using (var context = new CloudbassContext())
        //        {
        //            foreach (var schedule in schedules)
        //            {
        //                var record = context.Schedules.Find(schedule.Id);
        //                if (schedule != null)
        //                {
        //                    record.text = schedule.text;
        //                    //record.Crews = schedule.Crews;
        //                }
        //            }

        //            context.SaveChanges();

        //        }
        //    }


        //}
    }
}