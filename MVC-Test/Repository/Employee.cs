using MVC_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Test.Repository
{
    public partial class Repository
    {

        public IQueryable<Employee> Employees
        {
            get { return context.Employees; }
        }

        public bool CreateEmployees(Employee instance)
        {
            if (instance.Id == 0)
            {
                context.Employees.Add(instance);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateEmployees(Employee instance)
        {
            var cache = context.Employees.FirstOrDefault(o => o.Id == instance.Id);
            if (cache != null)
            {
                context.Entry(cache).CurrentValues.SetValues(instance);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool RemoveEmployees(int id)
        {
            var instance = context.Employees.FirstOrDefault(o => o.Id == id);
            if (instance != null)
            {
                context.Employees.Remove(instance);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}