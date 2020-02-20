using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_Test.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using MVC_Test.DAL;
using MVC_Test.Metadata;

namespace MVC_Test
{
    public class CloudbassContext : DbContext
    {//the name of the connection string added in the web.config is passews in to this constructor below
       
        //this is a constroctor to indicate the database the connecting string he's going to use to talk to DB
        public CloudbassContext() : base("CloudbassContext")
        {
            //new added
            Database.SetInitializer(new CloudbassInitializer());
        }

        // this state which entities are included in rthe data model
        public DbSet<Employee> Employees { get; set; }
        public DbSet<County> Counties { get; set; }
        public DbSet<Has_Role> Has_Roles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Crew> Crews { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Jobs> Jobs { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<BookingType> BookingTypes { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //this prevent table names from being pluralised
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<MVC_Test.Models.ViewModels.ScheduleEdit> ScheduleEdits { get; set; }
    }

}