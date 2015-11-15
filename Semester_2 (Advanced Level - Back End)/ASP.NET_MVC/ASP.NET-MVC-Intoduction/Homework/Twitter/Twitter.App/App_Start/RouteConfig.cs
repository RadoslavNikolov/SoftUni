using System.Web.Mvc;
using System.Web.Routing;

namespace Twitter.App
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Twitter.App.Controllers" }
            );





            //routes.MapRoute(
            //    name: "FollowUser",
            //    url: "{controller}/{action}/{username}",
            //    defaults: new
            //    {
            //        controller = "Users",
            //        action = "Follow"
            //    }
            //);

            //routes.MapRoute(
            //    name: "UserFollowing",
            //    url: "Users/UserFollowing/{username}",
            //    defaults: new
            //    {
            //        controller = "Users",
            //        action = "UserFollowing"
            //    }
            //);

            //routes.MapRoute(
            //    name: "UserFollowers",
            //    url: "Users/UserFollowers/{username}",
            //    defaults: new
            //    {
            //        controller = "Users",
            //        action = "UserFollowers"
            //    }
            //);

            //routes.MapRoute(
            //    name: "UserAccount",
            //    url: "{controller}/{action}/{username}",
            //    defaults: new
            //    {
            //        controller = "Users",
            //        action = "ViewUser"
            //    }
            //);

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);
        }
    }
}
