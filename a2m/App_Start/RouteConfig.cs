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
           /* RUTAS IGNORADAS */
           routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
           routes.IgnoreRoute("Content/{resource}");
           routes.IgnoreRoute("Content/{*pathInfo}");
           routes.IgnoreRoute("Static/{*pathInfo}");
           #if DEBUG 
                routes.IgnoreRoute("{*browserlink}", new { browserlink = @".*/arterySignalR/ping" }); 
           #endif
           /* RUTAS IGNORADAS */
           /* RUTAS API */
                routes.MapRoute(name: "API", url: "api/{action}", defaults: new { controller = "Api", action = "Index" });
           /* RUTAS API */
           /* RUTAS HOME */
           routes.MapRoute(name: "Inicio", url: "", defaults: new { controller = "Home", action = "Index" });
           routes.MapRoute(name: "Inicio - Ayuda", url: "ayuda", defaults: new { controller = "Home", action = "Help" });
           routes.MapRoute(name: "Inicio - Contacto", url: "contacto", defaults: new { controller = "Home", action = "Contact" });
           routes.MapRoute(name: "Inicio - Acerca de", url: "acerca-de-a2m", defaults: new { controller = "Home", action = "About" });
           /* RUTAS HOME */
           /* RUTAS MUNICIPIOS */
           routes.MapRoute(name: "Home municipio", url: "{municipality}", defaults: new { controller = "Municipality", action = "Index" });
           /* RUTAS MUNICIPIOS */
           /* RUTA Negocios */
           routes.MapRoute(name: "Home negocio", url: "{municipality}/{business}", defaults: new { controller = "Business", action = "Index" });
           /* RUTAS MUNICIPIOS */

           routes.MapRoute(name: "Generic Controllers",url: "{controller}/{action}", defaults: new { controller = "Home", action = "Index"} );

        }
    }
}
