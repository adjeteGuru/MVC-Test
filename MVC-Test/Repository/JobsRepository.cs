using MVC_Test.DataAccessLayer;
using MVC_Test.Models;
using MVC_Test.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace MVC_Test.Repository
{
    public class JobsRepository
    {
        public Job GetJob(string id)
        {
            if (id != string.Empty)
            {
                using (var context = new CloudbassContext())
                {
                    var job = context.Jobs.AsNoTracking()
                                            .Where(j => j.Id == id)
                                            .Single();
                    return job;
                }
            }
            return null;
        }

        public List<JobDisplayViewModel> GetJobs()
        {
            using (var context = new CloudbassContext())
            {
                List<Job> jobs = new List<Job>();
                jobs = context.Jobs.AsNoTracking()
                    .Include(j =>j.Client)
                    .ToList();

                if (jobs != null)
                {
                    List<JobDisplayViewModel> jobsDisplay = new List<JobDisplayViewModel>();

                    foreach (var j in jobs)
                    {
                        var jobDisplay = new JobDisplayViewModel()
                        {
                            Id = j.Id,
                            Name = j.Name,
                            DateCreated = j.DateCreated,
                            Location = j.Location,
                            Coordinator = j.Coordinator,
                            ClientName = j.Client.Name,
                            StartDate = j.StartDate,
                            TXDate = j.TXDate,
                            EndDate = j.EndDate,
                            CommercialLead = j.CommercialLead,
                            Status = j.Status
                        };

                        jobsDisplay.Add(jobDisplay);
                    }

                    return jobsDisplay;
                }

                return null;
            }

            
        }

        public JobEditViewModel CreateJob()
        {
          
            var cRepo = new ClientsRepository();
            var job = new JobEditViewModel()
            {
                //Id = ToString(),
                Id = Guid.NewGuid().ToString(),
                Clients = cRepo.GetClients()
            };

            return job;
        }

        public bool SaveJob(JobEditViewModel jobEdit)
        {
            if (jobEdit != null)
            {
                using (var context = new CloudbassContext())
                {
                    

                    if (string.IsNullOrEmpty(jobEdit.Id))
                    {

                        var job = new Job()
                    {
                        //Id = newGuid.ToString(),
                        Id = jobEdit.Id,
                        Name = jobEdit.Name,
                        ClientId = jobEdit.SelectedClientId,
                        Location = jobEdit.Location,
                        Coordinator = jobEdit.Coordinator,

                        StartDate = jobEdit.StartDate,
                            TXDate = jobEdit.TXDate,
                            EndDate = jobEdit.EndDate,
                        CommercialLead = jobEdit.CommercialLead,
                        Status = jobEdit.Status

                    };

                    job.Client = context.Clients.Find(jobEdit.SelectedClientId);
                    context.Jobs.Add(job);
                    context.SaveChanges();
                        return true;
                    }
                }
            }

            //return false if jobEdit == null or Id is not id 

            return false;
        }

        
    }
}