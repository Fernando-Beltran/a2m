using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace a2m
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("Content/{resource}");
            routes.IgnoreRoute("Content/{*pathInfo}");
            routes.IgnoreRoute("Static/{*pathInfo}");
            

           /* RUTAS HOME */
           routes.MapRoute(name: "Inicio", url: "", defaults: new { controller = "Home", action = "Index" });
           routes.MapRoute(name: "Inicio - Ayuda", url: "ayuda", defaults: new { controller = "Home", action = "Help" });
           routes.MapRoute(name: "Inicio - Contacto", url: "contacto", defaults: new { controller = "Home", action = "Contact" });
           routes.MapRoute(name: "Inicio - Acerca de", url: "acerca-de-a2m", defaults: new { controller = "Home", action = "About" });

           

            /* RUTAS HOME */

           routes.MapRoute(name: "Controllers",url: "{controller}/{action}/{id}", defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
           );

        }
    }
}
