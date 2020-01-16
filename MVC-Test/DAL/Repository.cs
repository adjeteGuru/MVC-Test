using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MVC_Test.Models;
using Ninject;
using MVC_Test.DAL;

namespace MVC_Test.DAL
{
    public partial class Repository
    {

        [Inject]
        public CloudbassContext context { get; set; }



        //private CloudbassContext context;

        //public Repository(CloudbassContext context)
        //{
        //    this.context = context;
        //}

        //public void DeleteJob(string Id)
        //{
        //    Job job = context.Jobs.Find(Id);
        //}

        //private bool disposed = false;
        //protected virtual void Dispose(bool disposing)
        //{
        //    if (!this.disposed)
        //    {
        //        if (disposing)
        //        {
        //            context.Dispose();
        //        }
        //    }
        //}
        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}

        //public Job GetJobByID(string Id)
        //{
        //    return context.Jobs.Find(Id);
        //}

        //public IEnumerable<Job> GetJobs()
        //{
        //    return context.Jobs.ToList();
        //}

        //public void InsertJob(Job job)
        //{
        //    context.Jobs.Add(job);
        //}

        //public void Save()
        //{
        //    context.SaveChanges();
        //}

        //public void UpdateJob(Job job)
        //{
        //   context.Entry(job).State = EntityState.Modified;
        //}

    }
}