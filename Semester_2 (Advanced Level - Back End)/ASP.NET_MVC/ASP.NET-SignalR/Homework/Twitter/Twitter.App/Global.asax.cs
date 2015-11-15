
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Twitter.App
{
    using System.Data.Entity;
    using Data;

    public class MvcApplication : System.Web.HttpApplication
    {


        protected void Application_Start()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TwitterContext, Twitter.Data.Migrations.Configuration>());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

    }
}
