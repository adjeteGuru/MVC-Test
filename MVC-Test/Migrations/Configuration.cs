﻿namespace MVC_Test.Migrations
{
    using MVC_Test.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVC_Test.CloudbassContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations";
        }

        protected override void Seed(MVC_Test.CloudbassContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            var clients = new List<Client>
                {
                new Client { Id ="it", name = "ITV", toContact = "Alexander Cooper", email = "alexander@gmail.com", address = "PO Box 12 london", tel = 02051122345 },
                new Client { Id ="al", name = "Al Jezeera", toContact = "Alonso Chi", email = "Alonso.gmail.com", address = "PO Box 12 london", tel = 02051122399 },
                new Client { Id ="bb", name = "BBC", toContact = "Anand Boer", email = "Anand@gmail.com", address = "PO Box 12 london", tel = 02051122367 }
                };
            clients.ForEach(client => context.Clients.AddOrUpdate(x => x.Id, client));
            context.SaveChanges();


            var roles = new List<Role>
                {
                new Role{Id=1, name="Rigger"},
                new Role{Id=2, name="Vision"},
                new Role{Id=3, name="Camera"},
                new Role{Id= 4, name="Sound Assistant"},
                new Role{Id= 5, name="Security"},
                new Role{Id=6, name="Camera Operator"},

            };

            roles.ForEach(role => context.Roles.AddOrUpdate(x => x.Id, role));
            context.SaveChanges();


            var counties = new List<County>
                {
                new County{Id=1, name="Nottinghamshire"},
                new County{Id=2, name="Derbyshire"},

            };

            counties.ForEach(county => context.Counties.AddOrUpdate(x => x.Id, county));
            context.SaveChanges();



            var orders = new List<Order>
                {
                new Order{OrderId=Guid.Parse("01c13f5d-e803-49aa-a9a4-003ee2042e16"), ServiceName="Camera", Quantity = 5, Rate= 200, Amount= 1000},
                new Order{OrderId=Guid.Parse("4627d75c-b72d-4372-8cc1-daffaafa866c"), ServiceName="Vision", Quantity = 4, Rate= 100, Amount= 400},
            };

            orders.ForEach(order => context.Orders.AddOrUpdate(x => x.OrderId, order));
            context.SaveChanges();


            var employees = new List<Employee>
                {
                new Employee{Id=1, fullName="Carson Alexander", start_date=DateTime.Parse("2005-09-01"), countyId=context.Counties.Find(1).Id, mobile= "09876654321", email="al@gmail.com", postNominals="BSc", bared="sky",isAvailable=true, alergy="nut", nextOfKin="frank",note="ohh",photo="pic.png", Category = Category.Staff,},
                new Employee{Id=2,fullName="Meredith Alonso",start_date=DateTime.Parse("2002-09-01") , countyId=context.Counties.Find(2).Id, mobile= "09876654321", email="al@gmail.com", postNominals="BSc", bared="sky",isAvailable=false, alergy="nut", nextOfKin="frank",note="ohh",photo="pic.png", Category = Category.Staff},
                new Employee{Id=3, fullName="Arturo Anand",start_date=DateTime.Parse("2003-09-01") , countyId=context.Counties.Find(1).Id, mobile= "09876654321", email="al@gmail.com", postNominals="BSc", bared="sky",isAvailable=true, alergy="nut", nextOfKin="frank",note="ohh",photo="pic.png", Category = Category.Freelance},
                new Employee{Id= 4,fullName="Gytis Barzdukas",start_date=DateTime.Parse("2002-09-01") , countyId=context.Counties.Find(2).Id, mobile= "09876654321", email="al@gmail.com", postNominals="BSc", bared="sky",isAvailable=true, alergy="nut", nextOfKin="frank",note="ohh",photo="pic.png", Category = Category.Staff},
                new Employee{Id=5,fullName="Yan Li",start_date=DateTime.Parse("2002-09-01"), countyId=context.Counties.Find(1).Id, mobile= "09876654321", email="al@gmail.com", postNominals="BSc", bared="sky",isAvailable=false, alergy="nut", nextOfKin="frank",note="ohh",photo="pic.png", Category = Category.Contracted},
                new Employee{Id=7, fullName="Peggy Justice",start_date=DateTime.Parse("2001-09-01"), countyId=context.Counties.Find(2).Id, mobile= "09876654321", email="al@gmail.com", postNominals="BSc", bared="sky",isAvailable=false, alergy="nut", nextOfKin="frank",note="ohh",photo="pic.png", Category = Category.Contracted},

                 };

            employees.ForEach(employee => context.Employees.AddOrUpdate(x => x.Id, employee));
            context.SaveChanges();



            var has_roles = new List<Has_Role>
                {
                new Has_Role{has_RoleId=1, employeeId=context.Employees.Find(1).Id,roleId=context.Roles.Find(1).Id},
                new Has_Role{has_RoleId=2, employeeId= context.Employees.Find(6).Id, roleId= context.Roles.Find(2).Id},
               new Has_Role{has_RoleId=3, employeeId=context.Employees.Find(2).Id,roleId=context.Roles.Find(1).Id},
               new Has_Role{ has_RoleId=4, employeeId=context.Employees.Find(3).Id,roleId=context.Roles.Find(3).Id},
                new Has_Role{has_RoleId=5, employeeId= context.Employees.Find(4).Id,roleId=context.Roles.Find(2).Id}

            };
            has_roles.ForEach(has_role => context.Has_Roles.AddOrUpdate(x => x.has_RoleId, has_role));
            context.SaveChanges();

            var crews = new List<Crew>
              {
            // new Crew{ crewId=1,JobId=context.Jobs.Find("cb12").JobId, has_RoleId=context.Has_Roles.Find(1).Id, start_date=DateTime.Parse("2019-12-11"), end_date=DateTime.Parse("2019-12-14"), totalDays= 1},
            //new Crew{JobId=context.Jobs.Find("cb12").Id,has_RoleId=context.Has_Roles.Find(2).Id, start_date=DateTime.Parse("2019-12-11"), end_date=DateTime.Parse("2019-12-14"), totalDays= 0.2, rate=270},
            //new Crew{JobId=context.Jobs.Find("cb13").JobId,has_RoleId=context.Has_Roles.Find(3).Id, start_date=DateTime.Parse("2019-12-11"), end_date=DateTime.Parse("2019-12-14"), totalDays= 1.5,
            //new Crew{JobId=context.Jobs.Find("cb13").Id,has_RoleId=context.Has_Roles.Find(1).Id, start_date=DateTime.Parse("2019-12-11"), end_date=DateTime.Parse("2019-12-14"), totalDays= 1, rate=270},
             // new Crew {  JobId = Guid.Parse("ad3ac28b-3652-ea11-8508-104a7dbc22bb"), has_RoleId= 1,start_date = new DateTime(2019, 3,11),end_date= new DateTime(2019, 5,11) ,totalDays= 1.5},


             };
            crews.ForEach(crew => context.Crews.AddOrUpdate(x => x.crewId, crew));
            context.SaveChanges();

            //     new Jobs{JobId= 17020a65-1b96-4120-b359-786ecca0c081, text="SPL",Description="friendly", Location="Scotland celtic park",Coordinator="Dixon", DateCreated=DateTime.Parse("2019-12-01"), start_date=DateTime.Parse("2019-12-11"), end_date=DateTime.Parse("2019-12-17"), Status = Status.Cancelled, CommercialLead="Francis Akai", ClientId= context.Clients.Find(2).Id},
            //     new Jobs{JobId="cb13",text="MUTV",Description="under 21 league", Location="Manchester Old traford",Coordinator="Sir Bobby", DateCreated=DateTime.Parse("2019-12-10"), start_date=DateTime.Parse("2019-12-11"), end_date=DateTime.Parse("2019-12-16"), Status = Status.Active, CommercialLead="Francis Akai", ClientId=context.Clients.Find(3).Id},

            //    });

            //

            //context.Schedules.AddRange(new List<Schedule> { 
            //{
            var schedules = new List<Schedule>
                {
                new Schedule{text="SPL-Travel", start_date=DateTime.Parse("2019-12-11"), end_date=DateTime.Parse("2019-12-11"), SchType = SchType.TrucksTravel, JobId = context.Jobs.Find(Guid.Parse("17020a65 - 1b96 - 4120 - b359 - 786ecca0c081")).JobId},
                new Schedule{text="SPL-Cable", start_date=DateTime.Parse("2019-12-11"), end_date=DateTime.Parse("2019-12-11"),SchType = SchType.CableRig, JobId = context.Jobs.Find(Guid.Parse("17020a65 - 1b96 - 4120 - b359 - 786ecca0c081")).JobId},
                new Schedule{text="SPL-Tech",start_date=DateTime.Parse("2019-12-12"), end_date=DateTime.Parse("2019-12-12"),SchType = SchType.TechRig, JobId = context.Jobs.Find(Guid.Parse("17020a65 - 1b96 - 4120 - b359 - 786ecca0c081")).JobId},
                new Schedule{text="SPL-Rehersal",start_date=DateTime.Parse("2019-12-13"), end_date=DateTime.Parse("2019-12-13"),SchType = SchType.Rehersal, JobId = context.Jobs.Find(Guid.Parse("17020a65 - 1b96 - 4120 - b359 - 786ecca0c081")).JobId},
                new Schedule{text="SPL-RX",start_date=DateTime.Parse("2019-12-14"), end_date=DateTime.Parse("2019-12-14"),SchType = SchType.RX, JobId = context.Jobs.Find(Guid.Parse("17020a65 - 1b96 - 4120 - b359 - 786ecca0c081")).JobId},
                new Schedule{text="SPL-1200KO", start_date=DateTime.Parse("2019-12-14"), end_date=DateTime.Parse("2019-12-14"), SchType = SchType.TX, JobId = context.Jobs.Find(Guid.Parse("17020a65 - 1b96 - 4120 - b359 - 786ecca0c081")).JobId},
                new Schedule{text="SPL-Derig",start_date=DateTime.Parse("2019-12-15"), end_date=DateTime.Parse("2019-12-15"),SchType = SchType.DarkDay, JobId =context.Jobs.Find(Guid.Parse("17020a65 - 1b96 - 4120 - b359 - 786ecca0c081")).JobId},
                new Schedule{text="SPL-Facs",start_date=DateTime.Parse("2019-12-15"), end_date=DateTime.Parse("2019-12-15"),SchType = SchType.Facs, JobId = context.Jobs.Find(Guid.Parse("17020a65 - 1b96 - 4120 - b359 - 786ecca0c081")).JobId},
                new Schedule{text="SPL-Travel Back", start_date=DateTime.Parse("2019-12-16"), end_date=DateTime.Parse("2019-12-17"), SchType = SchType.TrucksReturn, JobId = context.Jobs.Find(Guid.Parse("17020a65 - 1b96 - 4120 - b359 - 786ecca0c081")).JobId},
 
                //new Schedule{text="MUTV-Travel",start_date=DateTime.Parse("2019-12-11"), end_date=DateTime.Parse("2019-09-12"),SchType = SchType.TrucksTravel, JobId = context.Jobs.Find(c7f3b496-7851-ea11-8508-104a7dbc22bb).JobId},
                //new Schedule{text="MUTV-Cable",start_date=DateTime.Parse("2019-12-12"), end_date=DateTime.Parse("2019-12-12"),SchType = SchType.CableRig, JobId = context.Jobs.Find("cb13").JobId},
                //new Schedule{text="MUTV-Tech", start_date=DateTime.Parse("2019-12-12"), end_date=DateTime.Parse("2019-12-13"),SchType = SchType.TechRig, JobId = context.Jobs.Find("cb13").JobId},
                //new Schedule{text="MUTV-Rehersal", start_date=DateTime.Parse("2019-12-13"), end_date=DateTime.Parse("2019-12-13"),SchType = SchType.Rehersal, JobId = context.Jobs.Find("cb13").JobId},
                //new Schedule{text="MUTV-RX",start_date=DateTime.Parse("2019-12-13"), end_date=DateTime.Parse("2019-12-13"),SchType = SchType.RX, JobId = context.Jobs.Find("cb13").JobId},
                //new Schedule{text="MUTV-1945KO",start_date=DateTime.Parse("2019-12-14"), end_date=DateTime.Parse("2019-12-14"),SchType = SchType.TX, JobId = context.Jobs.Find("cb13").JobId},
                //new Schedule{text="MUTV-Derig", start_date=DateTime.Parse("2019-12-14"), end_date=DateTime.Parse("2019-12-14"),SchType = SchType.DeRig, JobId = context.Jobs.Find("cb13").JobId},
                //new Schedule{text="MUTV-Dark",start_date=DateTime.Parse("2019-12-15"), end_date=DateTime.Parse("2019-12-15"),SchType = SchType.DarkDay, JobId = context.Jobs.Find("cb13").JobId},
                //new Schedule{text="MUTV-Travel Back",start_date=DateTime.Parse("2019-12-16"), end_date=DateTime.Parse("2019-12-16"),SchType = SchType.TrucksReturn, JobId = context.Jobs.Find("cb13").JobId},
               // });
 
               
                 };
            schedules.ForEach(schedule => context.Schedules.AddOrUpdate(x => x.Id, schedule));
            context.SaveChanges();


            Jobs job = new Jobs
            {
                JobId = Guid.Parse("b8441b07-4052-ea11-9008-104a7dbc22bb"),
                text = "SPL",
                Description = "friendly",
                Location = "Scotland celtic park",
                Coordinator = "Dixon",
                DateCreated = DateTime.Parse("2019-12-01"),
                start_date = new DateTime(2016, 3, 11),
                end_date = DateTime.Parse("2019-12-17"),
                Status = Status.Cancelled,
                CommercialLead = "Francis Akai",
                ClientId = context.Clients.Find("it").Id,


            };

            context.Jobs.AddOrUpdate(o => o.JobId, job);




            context.SaveChanges();

            base.Seed(context);


        }
    }
}
