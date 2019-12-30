namespace MVC_Test.Migrations
{
    using MVC_Test.DataAccessLayer;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVC_Test.DataAccessLayer.CloudbassContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations";
        }

        protected override void Seed(MVC_Test.DataAccessLayer.CloudbassContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.Clients.AddOrUpdate(
              cl => new { cl.Id, cl.Name, cl.Tel, cl.ToContact, cl.Address }, CloudbassInitializer.getClients().ToArray());

            context.SaveChanges();


            context.Jobs.AddOrUpdate(
                j => new { j.Id, j.Name, j.Description }, CloudbassInitializer.getJobs(context).ToArray());

            context.SaveChanges();


            context.Counties.AddOrUpdate(
              c => new { c.Id, c.Name }, CloudbassInitializer.getCounties().ToArray());

            context.SaveChanges();

            context.Roles.AddOrUpdate(
               r => new { r.Id, r.Name }, CloudbassInitializer.getRoles().ToArray());

            context.SaveChanges();

            context.Employees.AddOrUpdate(
             e => new { e.FirstName, e.LastName }, CloudbassInitializer.getEmployees(context).ToArray());

            context.SaveChanges();

            context.Has_Roles.AddOrUpdate(
             hs => new { hs.StartTime, hs.EndTime }, CloudbassInitializer.getHas_Roles(context).ToArray());

            context.SaveChanges();


            context.Services.AddOrUpdate(
             cr => new { cr.StartTime, cr.EndTime, cr.totalDays, cr.Rate }, CloudbassInitializer.getServices(context).ToArray());

            context.SaveChanges();

            context.Schedules.AddOrUpdate(
             sc => new { sc.text, sc.start_date, sc.end_date, sc.SchType }, CloudbassInitializer.getSchedules(context).ToArray());

            context.SaveChanges();

        }
    }
}
