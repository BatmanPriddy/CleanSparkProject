using System.Web.Mvc;
using System.Web.Routing;

namespace VendingMachine
{
    /// <summary>
    /// Middleware class to wire up default route(s) and any custom routes
    /// </summary>
    public sealed class RouteConfig
    {
        /// <summary>
        /// Registers all routes used for this application
        /// </summary>
        /// <param name="routes">List of registered routes for this application</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}