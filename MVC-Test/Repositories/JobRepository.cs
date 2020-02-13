using MVC_Test.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Test.Repositories
{
    public class JobRepository
    {

        public List<Jobs> GetJobs()
        {
            using (var context = new CloudbassContext())
            {
                List<Models.Jobs> jobs = new List<Models.Jobs>();
                jobs = context.Jobs.AsNoTracking()
                  // .Include(x => x.Client)
                                   .ToList();

                if (jobs != null)
                {
                    List<Jobs> jobsDisplay = new List<Jobs>();

                    foreach (var j in jobs)
                    {
                        var jobDisplay = new Jobs()
                        {
                            JobId = j.JobId,
                            text = j.text,
                           Description = j.Description,
                            DateCreated = j.DateCreated,
                            Location = j.Location,
                            Coordinator = j.Coordinator,
                            
                            Client = j.ClientId,
                            start_date = j.start_date,
                            TXDate = j.TXDate,
                            end_date = j.end_date,
                            CommercialLead = j.CommercialLead,
                            JobRef =j.JobRef,
                            Status= j.Status
                            
                        };

                        jobsDisplay.Add(jobDisplay);
                    }

                    return jobsDisplay;
                }

                return null;
            }


        }


        public JobEdit GetJob(Guid id)
        {
            if (id != Guid.Empty)
            {
                using (var context = new CloudbassContext())
                {
                    var job = context.Jobs.AsNoTracking()
                                            .Where(j => j.JobId == id)
                                            .Single();

                    if (job != null)
                    {
                        var jobEditVm = new JobEdit()
                        {
                            JobId = job.JobId.ToString("D"),
                            text = job.text.Trim(),
                            Description = job.Description,
                            //NameConcatenateLocation = j.
                            DateCreated = job.DateCreated,
                            Location = job.Location,
                            Coordinator = job.Coordinator,
                            // ClientName = j.Client.Name,

                            start_date = job.start_date,
                            TXDate = job.TXDate,
                            end_date = job.end_date,
                            CommercialLead = job.CommercialLead,
                            SelectedClientId = job.Client.Id,
                            JobRef = job.JobRef,
                            Status = job.Status

                        };
                        var clientsRepo = new ClientRepository();
                        jobEditVm.Clients = clientsRepo.GetClients();
                        //var jobStatuRepo = new JobStatuRepository();
                        //jobEditVm.JobStatu = jobStatuRepo.GetJobStatus();

                        return jobEditVm;
                    }

                }
            }
            return null;
        }

        public JobEdit CreateJob()
        {

            var cRepo = new ClientRepository();

           

            var job = new JobEdit()
            {
                //Id = ToString(),
                JobId = Guid.NewGuid().ToString(),
                // Id = string.IsNullOrEmpty(string).ToString(),
                Clients = cRepo.GetClients(),
                //JobStatu = sRepo.GetJobStatus()

            };

            return job;
        }

        public bool SaveJob(JobEdit jobedit)
        {
            if (jobedit != null)
            {
                using (var context = new CloudbassContext())
                {

                    // if (string.IsNullOrEmpty(jobedit.Id))
                    if (Guid.TryParse(jobedit.JobId, out Guid newGuid))
                    {

                        var job = new Models.Jobs()
                        {
                            JobId = newGuid,
                            // Id = ToString(),
                            text = jobedit.text,
                            Description = jobedit.Description,

                            Location = jobedit.Location,
                            Coordinator = jobedit.Coordinator,
                            DateCreated = jobedit.DateCreated,

                            //NameConcatenateLocation = jobEdit.Name,
                            start_date = jobedit.start_date,
                            TXDate = jobedit.TXDate,
                            end_date = jobedit.end_date,
                            ClientId = jobedit.SelectedClientId,
                            // statusId = jobedit.SelectedStatus,
                            CommercialLead = jobedit.CommercialLead,
                            JobRef = jobedit.JobRef,
                            Status = jobedit.Status

                        };

                        job.Client = context.Clients.Find(jobedit.SelectedClientId);
                        //job.JobStatu = context.JobStatus.Find(jobedit.SelectedStatus);
                        context.Jobs.Add(job);
                        context.SaveChanges();
                        return true;
                    }
                }
            }

            // Return false if customeredit == null or CustomerID is not a guid
            return false;
        }

        // START SCHEDULE LIST

        // public List<Models.DTO.ScheduleListView> GetScheduleList(string jobid)
        public ScheduleList GetScheduleList(Guid jobid)
        {
            if (jobid != Guid.Empty)
            {
                using (var context = new CloudbassContext())
                {
                    var schedules = context.Schedules.AsNoTracking()
                        .Where(x => x.JobId == jobid)
                        .OrderBy(x => x.Id);

                    if (schedules != null)
                    {
                        var scheduleListView = new ScheduleList();
                        foreach (var schedule in schedules)
                        {
                            var scheduleVm = new Schedule()
                            {
                                JobId = schedule.JobId.ToString("D"),
                                Id = schedule.Id,
                                text = schedule.text,
                                SchType = schedule.SchType,
                                //SchTypeId = schedule.SchTypeId,
                                //SchTypName = schedule.SchType.name,
                                start_date = schedule.start_date,
                                end_date = schedule.end_date,
                                //StatusName = schedule.ScheduleStatu.title

                            };

                            //var schTypesRepo = new SchTypeRepository();
                            //scheduleVm.SchTypName = schTypesRepo.GetSchTypeName(schedule.SchTypeId);
                            //var jobStatuRepo = new JobStatuRepository();
                            //scheduleVm.StatusName = jobStatuRepo.GetJobStatuName(schedule.statusId);
                            //scheduleListView.Schedules.Add(scheduleVm);                                                   


                            //var schTypesRepo = new SchTypeRepository();
                            //scheduleVm.SchTypName = schTypesRepo.GetSchTypes().ToString();
                            //var schStatuRepo = new ScheduleStatuRepository();
                            //scheduleVm.StatusName = schStatuRepo.GetScheduleStatus().ToString();
                            //scheduleListView.Schedules.Add(scheduleVm);

                        }
                        return scheduleListView;
                    }
                }
            }
            return null;
        }


        //START SECOND

        //public List<Models.DTO.Schedule> GetSchedule(string jobid, int scheduleid)
        public Schedule GetSchedule(Guid jobid, int scheduleid)
        {
            if (jobid != Guid.Empty)
            {
                using (var context = new CloudbassContext())
                {
                    var schedule = context.Schedules.AsNoTracking()
                        .Where(x => x.JobId == jobid && x.Id == scheduleid)
                        .Single();


                    if (schedule != null)
                    {
                        var scheduleVm = new Schedule()
                        {
                            JobId = schedule.JobId.ToString("D"),
                            SchType =schedule.SchType,
                            text = schedule.text?.Trim(),

                            start_date = schedule.start_date,
                            end_date = schedule.end_date,


                        };


                        //var schTypesRepo = new SchTypeRepository();
                        //scheduleVm.SchTypName = schTypesRepo.GetSchTypeName(schedule.SchTypeId);
                        //var jobStatuRepo = new JobStatuRepository();
                        //scheduleVm.StatusName = jobStatuRepo.GetJobStatuName(schedule.statusId);


                        //var schTypesRepo = new SchTypeRepository();
                        //scheduleVm.SchTypName = schTypesRepo.GetSchTypes().ToString();
                        //var schStatuRepo = new ScheduleStatuRepository();
                        //scheduleVm.StatusName = schStatuRepo.GetScheduleStatus().ToString();



                        //var schTypesRepo = new SchTypeRepository();
                        //scheduleVm.SchTypName = schTypesRepo.GetSchTypes().ToString();
                        //var scheduleStatuRepo = new ScheduleStatuRepository();
                        //scheduleVm.StatusName = scheduleStatuRepo.GetScheduleStatus().ToString();
                        return scheduleVm;
                    }

                }
            }
            return null;

        }



        public ScheduleEdit SaveSchedule(ScheduleEdit model)
        {
            //if (model != null && string.IsNullOrEmpty(model.JobId) )

            if (model != null && Guid.TryParse(model.Id.ToString(), out Guid jobid))
            {
                using (var context = new CloudbassContext())
                {

                    var schedule = new Models.Schedule()
                    {
                        //Id = newGuid.ToString(),
                        //Id = customerid,
                        // JobId = model.JobId,

                        JobId = jobid,
                        text = model.text?.Trim(),

                        start_date = model.start_date,

                        end_date = model.end_date,
                        SchType = model.SchType
                        


                    };

                    //schedule.SchType = context.SchTypes.Find(schedule.SchTypeId);
                    //schedule.ScheduleStatu = context.ScheduleStatus.Find(schedule.statusId);
                    context.Schedules.Add(schedule);
                    context.SaveChanges();

                    //var schTypesRepo = new SchTypeRepository();
                    //model.SchType = schTypesRepo.GetSchTypes();
                    //var schStatuRepo = new ScheduleStatuRepository();
                    //model.ScheduleStatu = schStatuRepo.GetScheduleStatus();

                    return model;

                }
            }

            // Return false if customeredit == null or CustomerID is not a guid
            return null;
        }
    }
}