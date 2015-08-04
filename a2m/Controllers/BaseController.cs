using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace a2m.Controllers
{
    /// <summary>
    /// Controlador base del que heredan los que requieran estas funciones
    /// </summary>
    public class BaseController : Controller
    {
        /// <summary>
        /// Añade compresión GZIP a las vistas
        /// </summary>
        /// <example> Usage:
        ///             [Compress] 
        ///             public class BookingController : BaseController
        ///             {...}	
        ///
        ///             [CompressFilter]
        ///             public void Category(string name, int? page)
        /// </example>
        public class CompressAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {

                var encodingsAccepted = filterContext.HttpContext.Request.Headers["Accept-Encoding"];
                if (string.IsNullOrEmpty(encodingsAccepted)) return;

                encodingsAccepted = encodingsAccepted.ToLowerInvariant();
                var response = filterContext.HttpContext.Response;

                if (encodingsAccepted.Contains("deflate"))
                {
                    response.AppendHeader("Content-encoding", "deflate");
                    response.Filter = new DeflateStream(response.Filter, CompressionMode.Compress);
                }
                else if (encodingsAccepted.Contains("gzip"))
                {
                    response.AppendHeader("Content-encoding", "gzip");
                    response.Filter = new GZipStream(response.Filter, CompressionMode.Compress);
                }
            }
        }

        /// <summary>
        /// Añade el atributo No-CACHE a la vista
        /// </summary>
        public class NoCacheAttribute : ActionFilterAttribute
        {
            public override void OnResultExecuting(ResultExecutingContext filterContext)
            {
                filterContext.HttpContext.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
                filterContext.HttpContext.Response.Cache.SetValidUntilExpires(false);
                filterContext.HttpContext.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
                filterContext.HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                filterContext.HttpContext.Response.Cache.SetNoStore();

                base.OnResultExecuting(filterContext);
            }
        }

        /// <summary>
        /// Renderiza una vista como HTML para poder mostrarla desde peticiones AJAX
        /// </summary>
        /// <param name="viewName">Vista</param>
        /// <param name="model">Modelo</param>
        /// <returns>Cadena HTML con la vista ya renderizada</returns>
        public string RenderRazorViewToString(string viewName, object model)
        {

            ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext,
                                                                         viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View,
                                             ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }
        /// <summary>
        /// Renderiza una vista como HTML para poder mostrarla desde peticiones AJAX
        /// </summary>
        /// <param name="viewName">Vista</param>
        /// <returns>Cadena HTML con la vista ya renderizada</returns>
        public string RenderRazorViewToString(string viewName)
        {
            return RenderRazorViewToString(viewName, null);
        }
	}
}