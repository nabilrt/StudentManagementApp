using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Student_Management
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            );

            routes.MapRoute(
                         "Student",                                              // Route name
                         "{controller}/{action}/{id}",                           // URL with parameters
                         new { controller = "Student", action = "Index", id = "" }  // Parameter defaults
                     );
            routes.MapRoute(
                     "Student",                                              // Route name
                     "{controller}/{action}/{id}",                           // URL with parameters
                     new { controller = "Student", action = "createStudent", id = "" }  // Parameter defaults
                    );
            routes.MapRoute(
                     "Student",                                              // Route name
                     "{controller}/{action}/{id}",                           // URL with parameters
                     new { controller = "Student", action = "login", id = "" }  // Parameter defaults
                    );
            routes.MapRoute(
                     "Student",                                              // Route name
                     "{controller}/{action}/{id}",                           // URL with parameters
                     new { controller = "Student", action = "dashboard", id = "" }  // Parameter defaults
                    );
            routes.MapRoute(
                     "Home",                                              // Route name
                     "{controller}/{action}/{id}",                           // URL with parameters
                     new { controller = "Home", action = "About", id = "" }  // Parameter defaults
                    );
        }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
