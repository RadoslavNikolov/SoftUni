using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Template.App
{
    using System.Configuration;
    using System.Data.Entity;
    using System.Web.Caching;
    using Data;
    using Configuration = Data.Migrations.Configuration;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());

            AutoMapperConfig.Execute();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //This work with created database schema. If not throw error that "AspNetUsers" table do not exists.
            string cn = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlCacheDependencyAdmin.EnableTableForNotifications(cn, new[]{"AspNetUsers"});
        }

        public override string GetVaryByCustomString(HttpContext context, string arg)
        {
            if (arg == "host")
            {
                return context.Request.Headers["host"];
            }

            // whatever you have already, or just String.Empty
            return String.Empty;
        }

    }
}
