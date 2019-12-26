namespace MVC_Test.Migrations
{
    using MVC_Test.DataAccessLayer;
    using MVC_Test.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVC_Test.DataAccessLayer.CloudbassContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MVC_Test.DataAccessLayer.CloudbassContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            
            context.Clients.AddOrUpdate(
               cl => cl.Id, CloudbassInitializer.getClients().ToArray());

            context.SaveChanges();


            context.Jobs.AddOrUpdate(
                j => new {j.Name, j.Description, j.Location, j.StartDate, j.TXDate, j.EndDate, j.Coordinator, j.CommercialLead, j.ClientId, j.Status }, CloudbassInitializer.getJobs(context).ToArray());
            
            context.SaveChanges();


            context.Counties.AddOrUpdate(
              c => c.Id, CloudbassInitializer.getCounties().ToArray());

            context.SaveChanges();

            context.Roles.AddOrUpdate(
               r => r.Id,  CloudbassInitializer.getRoles().ToArray());

            context.SaveChanges();

            context.Employees.AddOrUpdate(
             e => new {e.FirstName, e.LastName }, CloudbassInitializer.getEmployees(context).ToArray());

            context.SaveChanges();

            //context.Has_Roles.AddOrUpdate(
            // hs => new { hs.StartTime, hs.EndTime, hs.EmployeeId, hs.RoleId}, CloudbassInitializer.getHas_Roles(context).ToArray());

            //context.SaveChanges();

            context.Has_Roles.AddOrUpdate(
             hs => hs.Id, CloudbassInitializer.getHas_Roles(context).ToArray());

            context.SaveChanges();


            context.Crews.AddOrUpdate(
             cr => new { cr.StartTime, cr.EndTime, cr.TotalHours, cr.Cost, cr.ScheduleId, cr.Has_RoleId }, CloudbassInitializer.getCrews(context).ToArray());

            context.SaveChanges();



            context.Schedules.AddOrUpdate(
             sc => new {sc.text, sc.start_date, sc.end_date, sc.SchType}, CloudbassInitializer.getSchedules().ToArray());

            context.SaveChanges();

          
        }
    }
}
