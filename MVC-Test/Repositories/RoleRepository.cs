using MVC_Test.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Test.Repositories
{
    public class RoleRepository
    {//serach 
        public List<Role> GetRoles()
        {
            using (CloudbassContext context = new CloudbassContext())
            {
                List<Models.Role> roles = new List<Models.Role>();

                roles = context.Roles.AsNoTracking()
                    .ToList();

                if (roles != null)
                {
                    List<Role> rolesList = new List<Role>();

                    foreach (var role in roles)
                    {
                        var currentDisplay = new Role()
                        {
                            Id = role.Id,
                            name = role.name
                        };
                        rolesList.Add(currentDisplay);

                    }

                    //return role as list
                    return rolesList;
                }
                return null;

            }

        } //End getRoles

        //public RoleEdit GetRole(int? id)
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
        //                var roleListView = new RoleList();
        //                foreach (var hasrole in hasroles)
        //                {
        //                    //var hasroleVm = new Role()
        //                    var roleVm = new Models.Role()
        //                    {
        //                        Id = hasrole.has_RoleId,
        //                        name = hasrole.Role.name

        //                    };
        //                    //Models.Role role = hasrole.Role;

        //                }
        //                return RoleSearch(roleListView);
        //            }
        //        }
        //    }
        //    return null;
        //}

        //public IEnumerable<SelectListItem> GetRoles()
        //{
        //    using (var context = new CloudbassContext())
        //    {
        //        List<SelectListItem> roles = context.Roles.AsNoTracking()
        //            .OrderBy(cl => cl.name)
        //            .Select(cl =>
        //            new SelectListItem
        //            {
        //                Value = cl.Id.ToString(),
        //                Text = cl.name
        //            }
        //            ).ToList();

        //        var roletip = new SelectListItem()
        //        {
        //            Value = null,
        //            Text = "---select role---"
        //        };
        //        roles.Insert(0, roletip);
        //        return new SelectList(roles, "Value", "Text");
        //    }
        //}
    }
    
}