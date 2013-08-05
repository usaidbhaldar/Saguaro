using System.Web.Mvc;
using System.Web.Routing;

// ReSharper disable CheckNamespace
namespace Saguaro
// ReSharper restore CheckNamespace
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Login",
                url: "login",
                defaults: new { controller = "Home", action = "Login", username = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Reports",
                url: "reports/{action}/{id}",
                defaults: new { controller = "Reports", action = "Index", username = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Admin",
                url: "admin/{action}/{id}",
                defaults: new { controller = "Admin", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Users",
                url: "users/{action}/{id}",
                defaults: new { controller = "Users", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Signout",
                url: "{controller}/{action}",
                defaults: new { controller = "Signout", action = "Index"}
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}