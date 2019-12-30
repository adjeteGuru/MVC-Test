using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MVC_Test.Models;

namespace MVC_Test.DataAccessLayer
{
    public class CloudbassInitializer : DropCreateDatabaseIfModelChanges<CloudbassContext>
     //public class CloudbassInitializer 
    {
        //protected override void Seed(+)
        public static List<Client> getClients()  
        {
            var clients = new List<Client>
                {
                new Client{Name="ITV",ToContact="Alexander Cooper",Email="alexander@gmail.com", Address="PO Box 12 london",Tel=02051122345},
                new Client{Name="Al Jezeera",ToContact="Alonso Chi",Email="Alonso.gmail.com",  Address="PO Box 12 london",Tel=02051122399},
                new Client{Name="BBC",ToContact="Anand Boer",Email="Anand@gmail.com",  Address="PO Box 12 london",Tel=02051122367},

                };

                return clients;
        }

            public static List<Job> getJobs(CloudbassContext context) 
            {

                var jobs = new List<Job>
                {
           
                 new Job{Id="cb12", Name="SPL",Description="friendly", Location="Scotland celtic park",Coordinator="Dixon", DateCreated=DateTime.Parse("2019-12-01"), StartDate=DateTime.Parse("2019-12-11"), EndDate=DateTime.Parse("2019-12-17"), Status = Status.Cancelled, CommercialLead="Francis Akai", ClientId= context.Clients.Find(2).Id},
                 new Job{Id="cb13",Name="MUTV",Description="under 21 league", Location="Manchester Old traford",Coordinator="Sir Bobby", DateCreated=DateTime.Parse("2019-12-10"), StartDate=DateTime.Parse("2019-12-11"), EndDate=DateTime.Parse("2019-12-16"), Status = Status.Active, CommercialLead="Francis Akai", ClientId=context.Clients.Find(3).Id},

                };
                return jobs;
            }

        public static List<Schedule> getSchedules(CloudbassContext context)
        {
            var schedules = new List<Schedule>
                {
                new Schedule{text="SPL-Travel", start_date=DateTime.Parse("2019-12-11"), end_date=DateTime.Parse("2019-12-11"), SchType = SchType.TrucksTravel, JobId = context.Jobs.Find("cb12").Id},
                new Schedule{text="SPL-Cable", start_date=DateTime.Parse("2019-12-11"), end_date=DateTime.Parse("2019-12-11"),SchType = SchType.CableRig, JobId = context.Jobs.Find("cb12").Id},
                new Schedule{text="SPL-Tech",start_date=DateTime.Parse("2019-12-12"), end_date=DateTime.Parse("2019-12-12"),SchType = SchType.TechRig, JobId = context.Jobs.Find("cb12").Id},
                new Schedule{text="SPL-Rehersal",start_date=DateTime.Parse("2019-12-13"), end_date=DateTime.Parse("2019-12-13"),SchType = SchType.Rehersal, JobId = context.Jobs.Find("cb12").Id},
                new Schedule{text="SPL-RX",start_date=DateTime.Parse("2019-12-14"), end_date=DateTime.Parse("2019-12-14"),SchType = SchType.RX, JobId = context.Jobs.Find("cb12").Id},
                new Schedule{text="SPL-1200KO", start_date=DateTime.Parse("2019-12-14"), end_date=DateTime.Parse("2019-12-14"), SchType = SchType.TX, JobId = context.Jobs.Find("cb12").Id},
                new Schedule{text="SPL-Derig",start_date=DateTime.Parse("2019-12-15"), end_date=DateTime.Parse("2019-12-15"),SchType = SchType.DarkDay, JobId =context.Jobs.Find("cb12").Id},
                new Schedule{text="SPL-Facs",start_date=DateTime.Parse("2019-12-15"), end_date=DateTime.Parse("2019-12-15"),SchType = SchType.Facs, JobId = context.Jobs.Find("cb12").Id},
                new Schedule{text="SPL-Travel Back", start_date=DateTime.Parse("2019-12-16"), end_date=DateTime.Parse("2019-12-17"), SchType = SchType.TrucksReturn, JobId = context.Jobs.Find("cb12").Id},

                new Schedule{text="MUTV-Travel",start_date=DateTime.Parse("2019-12-11"), end_date=DateTime.Parse("2019-09-12"),SchType = SchType.TrucksTravel, JobId = context.Jobs.Find("cb13").Id},
                new Schedule{text="MUTV-Cable",start_date=DateTime.Parse("2019-12-12"), end_date=DateTime.Parse("2019-12-12"),SchType = SchType.CableRig, JobId = context.Jobs.Find("cb13").Id},
                new Schedule{text="MUTV-Tech", start_date=DateTime.Parse("2019-12-12"), end_date=DateTime.Parse("2019-12-13"),SchType = SchType.TechRig, JobId = context.Jobs.Find("cb13").Id},
                new Schedule{text="MUTV-Rehersal", start_date=DateTime.Parse("2019-12-13"), end_date=DateTime.Parse("2019-12-13"),SchType = SchType.Rehersal, JobId = context.Jobs.Find("cb13").Id},
                new Schedule{text="MUTV-RX",start_date=DateTime.Parse("2019-12-13"), end_date=DateTime.Parse("2019-12-13"),SchType = SchType.RX, JobId = context.Jobs.Find("cb13").Id},
                new Schedule{text="MUTV-1945KO",start_date=DateTime.Parse("2019-12-14"), end_date=DateTime.Parse("2019-12-14"),SchType = SchType.TX, JobId = context.Jobs.Find("cb13").Id},
                new Schedule{text="MUTV-Derig", start_date=DateTime.Parse("2019-12-14"), end_date=DateTime.Parse("2019-12-14"),SchType = SchType.DeRig, JobId = context.Jobs.Find("cb13").Id},
                new Schedule{text="MUTV-Dark",start_date=DateTime.Parse("2019-12-15"), end_date=DateTime.Parse("2019-12-15"),SchType = SchType.DarkDay, JobId = context.Jobs.Find("cb13").Id},
                new Schedule{text="MUTV-Travel Back",start_date=DateTime.Parse("2019-12-16"), end_date=DateTime.Parse("2019-12-16"),SchType = SchType.TrucksReturn, JobId = context.Jobs.Find("cb13").Id},
                };

            return schedules;
        }

        public static List<Employee> getEmployees(CloudbassContext context)
        {

            var employees = new List<Employee>
                {
                new Employee{FirstName="Carson",LastName="Alexander",StartDate=DateTime.Parse("2005-09-01"), CountyId=context.Counties.Find(1).Id, Mobile= "09876654321", Email="al@gmail.com", PostNominals="BSc", bared="sky",IsAvailable=true, Alergy="nut", NextOfKin="frank",Note="ohh",Photo="pic.png", Category = Category.Staff,},
                new Employee{FirstName="Meredith",LastName="Alonso",StartDate=DateTime.Parse("2002-09-01") , CountyId=context.Counties.Find(2).Id, Mobile= "09876654321", Email="al@gmail.com", PostNominals="BSc", bared="sky",IsAvailable=false, Alergy="nut", NextOfKin="frank",Note="ohh",Photo="pic.png", Category = Category.Staff},
                new Employee{FirstName="Arturo",LastName="Anand",StartDate=DateTime.Parse("2003-09-01") , CountyId=context.Counties.Find(1).Id, Mobile= "09876654321", Email="al@gmail.com", PostNominals="BSc", bared="sky",IsAvailable=true, Alergy="nut", NextOfKin="frank",Note="ohh",Photo="pic.png", Category = Category.Freelance},
                new Employee{FirstName="Gytis",LastName="Barzdukas",StartDate=DateTime.Parse("2002-09-01") , CountyId=context.Counties.Find(2).Id, Mobile= "09876654321", Email="al@gmail.com", PostNominals="BSc", bared="sky",IsAvailable=true, Alergy="nut", NextOfKin="frank",Note="ohh",Photo="pic.png", Category = Category.Staff},
                new Employee{FirstName="Yan",LastName="Li",StartDate=DateTime.Parse("2002-09-01"), CountyId=context.Counties.Find(1).Id, Mobile= "09876654321", Email="al@gmail.com", PostNominals="BSc", bared="sky",IsAvailable=false, Alergy="nut", NextOfKin="frank",Note="ohh",Photo="pic.png", Category = Category.Contracted},
                new Employee{FirstName="Peggy",LastName="Justice",StartDate=DateTime.Parse("2001-09-01"), CountyId=context.Counties.Find(2).Id, Mobile= "09876654321", Email="al@gmail.com", PostNominals="BSc", bared="sky",IsAvailable=false, Alergy="nut", NextOfKin="frank",Note="ohh",Photo="pic.png", Category = Category.Contracted},

                };
            return employees;
        }

        public static List<County> getCounties()
        {

            var counties = new List<County>
                {
                new County{ Name="Nottinghamshire"},
                new County{Name="Derbyshire"},

                };

            return counties;
        }

        public static List<Has_Role> getHas_Roles(CloudbassContext context)
        {

            var has_roles = new List<Has_Role>
                {
                new Has_Role{EmployeeId=context.Employees.Find(5).Id,RoleId=context.Roles.Find(5).Id, StartTime=DateTime.Parse("2019-12-11"), EndTime=DateTime.Parse("2019-12-14")},
                new Has_Role{EmployeeId= context.Employees.Find(6).Id, RoleId= context.Roles.Find(2).Id, StartTime=DateTime.Parse("2019-12-11"), EndTime=DateTime.Parse("2019-12-14")},
               new Has_Role{EmployeeId=context.Employees.Find(2).Id,RoleId=context.Roles.Find(1).Id, StartTime=DateTime.Parse("2019-12-11"), EndTime=DateTime.Parse("2019-12-12")},
               new Has_Role{EmployeeId=context.Employees.Find(3).Id,RoleId=context.Roles.Find(4).Id, StartTime=DateTime.Parse("2019-12-11"), EndTime=DateTime.Parse("2019-12-11")},
                new Has_Role{EmployeeId= context.Employees.Find(4).Id,RoleId=context.Roles.Find(3).Id, StartTime=DateTime.Parse("2019-12-11"), EndTime=DateTime.Parse("2019-12-13")},

                };

            return has_roles;
        }


        public static List<Role> getRoles()
        {
            var roles = new List<Role>
                {
                new Role{Name="Rigger"},
                new Role{Name="Vision"},
                new Role{Name="Camera"},
                new Role{Name="Sound Assistant"},
                new Role{Name="Security"},
                new Role{Name="Camera Operator"},

                };
            return roles;
        }

        public static List<Service> getServices(CloudbassContext context)
        {

            var services = new List<Service>
                {
                new Service{ScheduleId=context.Schedules.Find(1).Id, Has_RoleId=context.Has_Roles.Find(1).Id, StartTime=DateTime.Parse("2019-12-11"), EndTime=DateTime.Parse("2019-12-14"), totalDays= 1, Rate=270},
                new Service{ScheduleId=context.Schedules.Find(2).Id,Has_RoleId=context.Has_Roles.Find(2).Id, StartTime=DateTime.Parse("2019-12-11"), EndTime=DateTime.Parse("2019-12-14"), totalDays= 0.2, Rate=270},
                new Service{ScheduleId=context.Schedules.Find(3).Id,Has_RoleId=context.Has_Roles.Find(3).Id, StartTime=DateTime.Parse("2019-12-11"), EndTime=DateTime.Parse("2019-12-14"), totalDays= 1.5, Rate=275},
                new Service{ScheduleId=context.Schedules.Find(4).Id,Has_RoleId=context.Has_Roles.Find(1).Id, StartTime=DateTime.Parse("2019-12-11"), EndTime=DateTime.Parse("2019-12-14"), totalDays= 1, Rate=270},
                new Service{ScheduleId=context.Schedules.Find(5).Id,Has_RoleId=context.Has_Roles.Find(2).Id,StartTime=DateTime.Parse("2019-12-11"), EndTime=DateTime.Parse("2019-12-14"), totalDays= 1.5, Rate=250},

                };
            return services;
        }

        }

    }
