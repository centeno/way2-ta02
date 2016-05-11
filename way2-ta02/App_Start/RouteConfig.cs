using System.Diagnostics.CodeAnalysis;
using System.Web.Mvc;
using System.Web.Routing;

namespace way2_ta02
{
    [ExcludeFromCodeCoverage]
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "",
                defaults: new { controller = "Home", action = "Index" }
            );

            routes.MapRoute(
                name: "Repositories",
                url: "{user}",
                defaults: new { controller = "Home", action = "Repositories" }
            );

            routes.MapRoute(
                name: "Repository",
                url: "{user}/{repository}/",
                defaults: new { controller = "Home", action = "Repository" }
            );

            routes.MapRoute(
                name: "Favorite",
                url: "{user}/{repository}/favorite",
                defaults: new { controller = "Home", action = "Favorite" }
            );

            routes.MapRoute(
                name: "Unfavorite",
                url: "{user}/{repository}/unfavorite",
                defaults: new { controller = "Home", action = "Unfavorite" }
            );
        }
    }
}
