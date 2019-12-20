namespace MVC_Test.Migrations
{
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
            var clients = new List<Client>
            {
                new Client{ Id= 1, Name="ITV",ToContact="Alexander Cooper",Email="alexander@gmail.com", Address="PO Box 12 london",Tel=02051122345},
                new Client{Id= 2, Name="Al Jezeera",ToContact="Alonso Chi",Email="Alonso.gmail.com",  Address="PO Box 12 london",Tel=02051122399},
                new Client{Id=3,Name="BBC",ToContact="Anand Boer",Email="Anand@gmail.com",  Address="PO Box 12 london",Tel=02051122367},
            };
            clients.ForEach(cl => context.Clients.Add(cl));
            context.SaveChanges();


            var jobs = new List<Job>
            {
            //new Job{Id="cb11", Name="Silverstone",Description="racing", Location="Carson",Coordinator="Alexander", DateCreated=DateTime.Parse("2019-12-01"), StartDate=DateTime.Parse("2019-12-10"), TXDate=DateTime.Parse("2019-12-10"), EndDate=DateTime.Parse("2019-12-14"), Status = Status.InQuotation, CommercialLead="Francis Akai", ClientId=1},
             new Job{Id="cb12", Name="SPL",Description="friendly", Location="Scotland celtic park",Coordinator="Dixon", DateCreated=DateTime.Parse("2019-12-01"), StartDate=DateTime.Parse("2019-12-10"),TXDate=DateTime.Parse("2019-12-10"), EndDate=DateTime.Parse("2019-12-14"), Status = Status.Cancelled, CommercialLead="Francis Akai", ClientId=2},
             new Job{Id="cb13", Name="MUTV",Description="under 21 league", Location="Manchester Old traford",Coordinator="Sir Bobby", DateCreated=DateTime.Parse("2019-12-10"), StartDate=DateTime.Parse("2019-12-12"),TXDate=DateTime.Parse("2019-12-10"), EndDate=DateTime.Parse("2019-12-12"), Status = Status.Active, CommercialLead="Francis Akai", ClientId=3},

            };
            jobs.ForEach(j => context.Jobs.Add(j));
            context.SaveChanges();

            var schedules = new List<Schedule>
            {
            new Schedule{text="SPL-Travel", start_date=DateTime.Parse("2019-12-11"), end_date=DateTime.Parse("2019-12-11"), SchType = SchType.TrucksTravel, JobId = "cb12"},
            new Schedule{text="SPL-Cable", start_date=DateTime.Parse("2019-12-11"), end_date=DateTime.Parse("2019-12-11"),SchType = SchType.CableRig, JobId = "cb12"},
            new Schedule{text="SPL-Tech",start_date=DateTime.Parse("2019-12-12"), end_date=DateTime.Parse("2019-12-12"),SchType = SchType.TechRig, JobId = "cb12"},
            new Schedule{text="SPL-Rehersal",start_date=DateTime.Parse("2019-12-13"), end_date=DateTime.Parse("2019-12-13"),SchType = SchType.Rehersal, JobId = "cb12"},
            new Schedule{text="SPL-RX",start_date=DateTime.Parse("2019-12-14"), end_date=DateTime.Parse("2019-12-14"),SchType = SchType.RX, JobId = "cb12"},
             new Schedule{text="SPL-1200KO", start_date=DateTime.Parse("2019-12-11"), end_date=DateTime.Parse("2019-12-13"), SchType = SchType.TX, JobId = "cb12"},
            new Schedule{text="SPL-Cable", start_date=DateTime.Parse("2019-12-11"), end_date=DateTime.Parse("2019-12-13"),SchType = SchType.DeRig, JobId = "cb12"},
            new Schedule{text="SPL-Derig",start_date=DateTime.Parse("2019-12-13"), end_date=DateTime.Parse("2019-12-14"),SchType = SchType.DarkDay, JobId = "cb12"},
            new Schedule{text="SPL-Dark",start_date=DateTime.Parse("2019-12-13"), end_date=DateTime.Parse("2019-12-14"),SchType = SchType.Facs, JobId = "cb12"},
            new Schedule{text="SPL-Travel", start_date=DateTime.Parse("2019-12-14"), end_date=DateTime.Parse("2019-12-14"), SchType = SchType.TrucksTravel, JobId = "cb12"},

            new Schedule{ text="MUTV-Travel",start_date=DateTime.Parse("2019-12-11"), end_date=DateTime.Parse("2019-09-11"),SchType = SchType.TrucksTravel, JobId = "cb13"},
            new Schedule{text="MUTV-Cable",start_date=DateTime.Parse("2019-12-11"), end_date=DateTime.Parse("2019-12-11"),SchType = SchType.TrucksTravel, JobId = "cb13"},
            new Schedule{text="MUTV-Tech", start_date=DateTime.Parse("2019-12-12"), end_date=DateTime.Parse("2019-12-12"),SchType = SchType.TrucksTravel, JobId = "cb13"},
            new Schedule{text="MUTV-Rehersal", start_date=DateTime.Parse("2019-12-13"), end_date=DateTime.Parse("2019-12-13"),SchType = SchType.TrucksTravel, JobId = "cb13",},
            new Schedule{text="MUTV-RX",start_date=DateTime.Parse("2019-12-12"), end_date=DateTime.Parse("2019-12-13"),SchType = SchType.TrucksTravel, JobId = "cb13"},
            new Schedule{text="MUTV-1945KO",start_date=DateTime.Parse("2019-12-13"), end_date=DateTime.Parse("2019-12-13"),SchType = SchType.TrucksTravel, JobId = "cb13"},
            new Schedule{text="MUTV-Cable", start_date=DateTime.Parse("2019-12-12"), end_date=DateTime.Parse("2019-12-13"),SchType = SchType.TrucksTravel, JobId = "cb13"},
            new Schedule{text="MUTV-Derig", start_date=DateTime.Parse("2019-12-14"), end_date=DateTime.Parse("2019-12-14"),SchType = SchType.TrucksTravel, JobId = "cb13",},
            new Schedule{text="MUTV-Dark",start_date=DateTime.Parse("2019-12-14"), end_date=DateTime.Parse("2019-12-14"),SchType = SchType.TrucksTravel, JobId = "cb13"},
            new Schedule{text="MUTV-Travel",start_date=DateTime.Parse("2019-12-14"), end_date=DateTime.Parse("2019-12-14"),SchType = SchType.TrucksTravel, JobId = "cb13"},
            };
            schedules.ForEach(sc => context.Schedules.Add(sc));
            context.SaveChanges();

            var employees = new List<Employee>
            {
            new Employee{FirstName="Carson",LastName="Alexander",StartDate=DateTime.Parse("2005-09-01"), CountyId=1, Mobile= "09876654321", Email="al@gmail.com", PostNominals="BSc", bared="sky",IsAvailable=true, Alergy="nut", NextOfKin="frank",Note="ohh",Photo="pic.png"},
            new Employee{FirstName="Meredith",LastName="Alonso",StartDate=DateTime.Parse("2002-09-01") , CountyId=2, Mobile= "09876654321", Email="al@gmail.com", PostNominals="BSc", bared="sky",IsAvailable=false, Alergy="nut", NextOfKin="frank",Note="ohh",Photo="pic.png"},
            new Employee{FirstName="Arturo",LastName="Anand",StartDate=DateTime.Parse("2003-09-01") , CountyId=1, Mobile= "09876654321", Email="al@gmail.com", PostNominals="BSc", bared="sky",IsAvailable=true, Alergy="nut", NextOfKin="frank",Note="ohh",Photo="pic.png"},
            new Employee{FirstName="Gytis",LastName="Barzdukas",StartDate=DateTime.Parse("2002-09-01") , CountyId=2, Mobile= "09876654321", Email="al@gmail.com", PostNominals="BSc", bared="sky",IsAvailable=true, Alergy="nut", NextOfKin="frank",Note="ohh",Photo="pic.png"},
            new Employee{FirstName="Yan",LastName="Li",StartDate=DateTime.Parse("2002-09-01"), CountyId=1, Mobile= "09876654321", Email="al@gmail.com", PostNominals="BSc", bared="sky",IsAvailable=false, Alergy="nut", NextOfKin="frank",Note="ohh",Photo="pic.png"},
            new Employee{FirstName="Peggy",LastName="Justice",StartDate=DateTime.Parse("2001-09-01"), CountyId=2, Mobile= "09876654321", Email="al@gmail.com", PostNominals="BSc", bared="sky",IsAvailable=false, Alergy="nut", NextOfKin="frank",Note="ohh",Photo="pic.png"},

            };

            employees.ForEach(e => context.Employees.Add(e));
            context.SaveChanges();

            var counties = new List<County>
            {
            new County{Name="Nottinghamshire"},
            new County{Name="Derbyshire"},

            };
            counties.ForEach(c => context.Counties.Add(c));
            context.SaveChanges();

            var has_roles = new List<Has_Role>
            {
            new Has_Role{EmployeeId=1,RoleId=1,StartTime=DateTime.Parse("2019-12-11"), EndTime=DateTime.Parse("2019-12-14")},
            new Has_Role{EmployeeId=1,RoleId=2,StartTime=DateTime.Parse("2019-12-11"), EndTime=DateTime.Parse("2019-12-14")},
           new Has_Role{EmployeeId=2,RoleId=1,StartTime=DateTime.Parse("2019-12-11"), EndTime=DateTime.Parse("2019-12-12")},
           new Has_Role{EmployeeId=3,RoleId=4,StartTime=DateTime.Parse("2019-12-11"), EndTime=DateTime.Parse("2019-12-11")},
            new Has_Role{EmployeeId=4,RoleId=3,StartTime=DateTime.Parse("2019-12-11"), EndTime=DateTime.Parse("2019-12-13")},

            };
            has_roles.ForEach(hr => context.Has_Roles.Add(hr));
            context.SaveChanges();


            var roles = new List<Role>
            {
            new Role{Name="Rigger"},
            new Role{Name="Vision"},
            new Role{Name="Camera"},
            new Role{Name="Sound Assistant"},
            new Role{Name="Security"},
            new Role{Name="Camera Operator"},

            };
            roles.ForEach(r => context.Roles.Add(r));
            context.SaveChanges();

            var crews = new List<Crew>
            {
            new Crew{ScheduleId=1,Has_RoleId=1,StartTime=DateTime.Parse("2019-12-11"), EndTime=DateTime.Parse("2019-12-14"), Category = Category.Staff, TotalHours= 12, Cost=200},
            new Crew{ScheduleId=2,Has_RoleId=2,StartTime=DateTime.Parse("2019-12-11"), EndTime=DateTime.Parse("2019-12-14"), Category = Category.Staff, TotalHours= 12, Cost=200},
            new Crew{ScheduleId=3,Has_RoleId=3,StartTime=DateTime.Parse("2019-12-11"), EndTime=DateTime.Parse("2019-12-14"), Category = Category.Freelance, TotalHours= 12, Cost=200},
            new Crew{ScheduleId=4,Has_RoleId=1,StartTime=DateTime.Parse("2019-12-11"), EndTime=DateTime.Parse("2019-12-14"), Category = Category.Staff, TotalHours= 12, Cost=200},
            new Crew{ScheduleId=5,Has_RoleId=2,StartTime=DateTime.Parse("2019-12-11"), EndTime=DateTime.Parse("2019-12-14"), Category = Category.Contracted, TotalHours= 28, Cost=200},

            };
            crews.ForEach(cr => context.Crews.Add(cr));
            context.SaveChanges();
        }
    }
}
