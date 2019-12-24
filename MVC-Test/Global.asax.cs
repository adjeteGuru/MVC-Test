using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Entity;
using MVC_Test.Models;
using MVC_Test.DataAccessLayer;

namespace MVC_Test
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {// this line bellow get a database recreated from seed data every time you start the application
           // Database.SetInitializer(new CloudbassInitializer());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
