﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_Test.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MVC_Test.DataAccessLayer
{
    public class CloudbassContext : DbContext
    {//the name of the connection string added in the web.config is passews in to this constructor below
        public CloudbassContext() : base("CloudbassContext")
        {
        }

        // this state which entities are included in rthe data model
        public DbSet<Employee> Employees { get; set; }
        public DbSet<County> Counties { get; set; }
        public DbSet<Has_Role> Has_Roles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Crew> Crews { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Client> Clients { get; set; }
     

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //this prevent table names from being pluralised
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

     
    }

}