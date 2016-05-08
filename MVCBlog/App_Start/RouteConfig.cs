using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCBlog
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "SiteHome",
                url: "Anasayfa",
                defaults: new { controller = "SiteHome", action = "Index" }
                );

            routes.MapRoute(
                name: "BlogHaber",
                url: "Blog/{title}/{id}",
                defaults: new { controller = "SiteBlog", action = "Index", id = UrlParameter.Optional, title = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "SiteHome", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
