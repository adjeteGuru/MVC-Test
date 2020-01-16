using MVC_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_Test.DAL;

namespace MVC_Test.DAL
{
   public interface IRepository
    {
        //IEnumerable<Job> GetJobs();
        //Job GetJobByID(string Id);
        //void InsertJob(Job job);
        //void UpdateJob(Job job);
        //void DeleteJob(string Id);
        //void Save();
       // public CloudbassContext context { get; set; }
        IQueryable<Job> Jobs { get; }
        bool CreateJob(Job instance);
        bool UpdateJob(Job instance);
        bool RemoveJob(string id);
        bool RemoveJobCondition(IQueryable<Job> instances);

        IQueryable<Client> Clients { get; }
        bool CreateClient(Client instance);
        bool UpdateClient(Client instance);
        bool RemoveClient(int id);

        IQueryable<Schedule> Schedules { get; }
        bool CreateSchedule(Schedule instance);
        bool UpdateSchedule(Schedule instance);
        bool RemoveSchedule(int id);
        bool RemoveScheduleCondition(IQueryable<Schedule> instances);

        IQueryable<County> Counties { get; }
        bool CreateCounty(County instance);
        bool UpdateCounty(County instance);
        bool RemoveCounty(int id);

        IQueryable<Employee> Employees { get; }
        bool CreateEmployee(Employee instance);
        bool UpdateEmployee(Employee instance);
        bool RemoveEmployee(int id);
     

        IQueryable<Has_Role> Has_Roles { get; }
        bool CreateHas_Role(Has_Role instance);
        bool UpdateHas_Role(Has_Role instance);
        bool RemoveHas_Role(int id);


        IQueryable<Role> Roles { get; }
        bool CreateRole(Role instance);
        bool UpdateRole(Role instance);
        bool RemoveRole(int id);

        IQueryable<Crew> Crews { get; }
        bool CreateCrew(Crew instance);
        bool UpdateCrew(Crew instance);
        bool RemoveCrew(int id);


    }
}
