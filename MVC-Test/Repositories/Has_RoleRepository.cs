using MVC_Test.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Test.Repositories
{
    public class Has_RoleRepository
    {
        //ADD COMBO GET/LIST/SAVE VIEWMODEL

        //get list
        public Has_RoleList GetHas_RoleList(int? hasroleid)
        {           
            if (hasroleid != null)
            {
                using (var context = new CloudbassContext())
                {
                    var combos = context.Has_Roles.AsNoTracking()
                        .Where(x => x.has_RoleId == hasroleid)
                        .OrderBy(x => x.has_RoleId);

                    if (combos != null)
                    {
                        var comboListView = new Has_RoleList();
                        foreach (var combo in combos)
                        {
                            var comboVm = new Has_Role()
                            {
                                Id = combo.has_RoleId,
                                employeeId = combo.employeeId,

                                //fullName = combo.Has_Role.Employee.fullName,
                                roleId = combo.roleId,
                                // has_RoleId = combo.Has_Role.Role.Id,
                                //totalDays = combo.totalDays,

                                start_date = combo.start_date,
                                end_date = combo.end_date,
                                rate = combo.rate

                            };


                        }
                        return comboListView;
                    }
                }
            }
            return null;
        }



        //get crew
        public Has_Role GetHas_Role(int? jobid, int hasroleid)
        {

            if (jobid != null)
            
            {
                using (var context = new CloudbassContext())
                {
                    List<Models.Has_Role> has_Roles = context.Has_Roles.ToList();
                    List<Models.Role> roles = context.Roles.ToList();
                    List<Models.Employee> employees = context.Employees.ToList();

                    var hasrole = context.Has_Roles.AsNoTracking()
                        .Where(x => x.has_RoleId == jobid && x.has_RoleId == hasroleid)
                        .Single();


                    if (hasrole != null)
                    {
                        var comboVm = new Has_Role()
                        
                        {

                            Id = hasrole.has_RoleId,
                            employeeId = hasrole.employeeId,

                            // fullName = hasrole.Has_Role.Employee.fullName,
                            roleId = hasrole.roleId,
                            // has_RoleId = combo.Has_Role.Role.Id,
                            rate = hasrole.rate,

                            start_date = hasrole.start_date,
                            end_date = hasrole.end_date


                        };


                        return comboVm;
                    }

                }
            }
            return null;

        }


        //Save Crew//
        public Has_RoleEdit SaveHas_Role(Has_RoleEdit model)
        {
           
            if (model != null /*&& Guid.TryParse(model.JobId, out Guid jobid)*/ )
            {
                using (var context = new CloudbassContext())
                {
                    List<Models.Has_Role> has_Roles = context.Has_Roles.ToList();
                    List<Models.Role> roles = context.Roles.ToList();
                    List<Models.Employee> employees = context.Employees.ToList();
                    var combo = new Models.Has_Role()
                    {

                        employeeId = model.employeeId,
                        roleId = model.roleId,
                       
                        start_date = model.start_date,

                        end_date = model.end_date,

                        rate = model.rate


                    };


                    context.Has_Roles.Add(combo);
                    context.SaveChanges();


                    return model;

                }
            }

            // Return false if customeredit == null or CustomerID is not a guid
            return null;
        }



        
    }
}