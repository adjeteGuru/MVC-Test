using MVC_Test.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Test.Repositories
{
    public class EmployeeRepository
    {
        public List<Employee> GetEmployees()
        {
            using (var context = new CloudbassContext())
            {
                List<Models.Employee> employees = new List<Models.Employee>();
                employees = context.Employees.AsNoTracking()
                    .ToList();
                if (employees != null)
                {
                    var employeesList = new List<Employee>();
                    foreach (var employee in employees)
                    {
                        var currentDisplay = new Employee()
                        {
                            Id = employee.Id,
                            fullName = employee.fullName,


                        };

                        employeesList.Add(currentDisplay);
                    }
                    //return employee as a list
                    return employeesList;
                }

                return null;
            }


        } //end getEmployee

        //public EmployeeEdit GetEmployee(int? id)
        //{
        //    if (id != null)
        //    {
        //        using (var context = new CloudbassContext())
        //        {
        //            var hasroles = context.Has_Roles.AsNoTracking()
        //                .Where(x => x.has_RoleId == id)
        //                .OrderBy(x => x.has_RoleId);

        //            if (hasroles != null)
        //            {
        //                var empListView = new EmployeeList();
        //                foreach (var hasrole in hasroles)
        //                {
        //                    //var hasroleVm = new Role()
        //                    var employeeVm = new Models.Employee()
        //                    {
        //                        Id = hasrole.has_RoleId,
        //                        fullName = hasrole.Employee.fullName

        //                    };


        //                }
        //                return empListView;
        //            }
        //        }
        //    }
        //    return null;
        //}



        //public IEnumerable<SelectListItem> GetEmployees()
        //{
        //    using (var context = new CloudbassContext())
        //    {
        //        List<SelectListItem> employees = context.Employees.AsNoTracking()
        //            .OrderBy(cl => cl.fullName)
        //            .Select(cl =>
        //            new SelectListItem
        //            {
        //                Value = cl.Id.ToString(),
        //                Text = cl.fullName
        //            }
        //            ).ToList();

        //        var employeetip = new SelectListItem()
        //        {
        //            Value = null,
        //            Text = "---select employee---"
        //        };
        //        employees.Insert(0, employeetip);
        //        return new SelectList(employees, "Value", "Text");
        //    }
        //}
    }
}
