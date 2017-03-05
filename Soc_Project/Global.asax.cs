using Soc_Project.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Soc_Project
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            AutofacConfig.ConfigureContainer();
            AutomapperConfig.Config();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
