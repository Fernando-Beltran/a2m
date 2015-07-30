using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Script.Serialization;  
using Newtonsoft.Json;
using a2m.Common.Responses;


namespace a2m.Controllers
{
    /// <summary>
    /// Controlador para el API de JSON
    /// </summary>
    public class ApiController : Controller  
    {
        [System.Web.Http.HttpPost]
        public JsonResult Index()
        {
            string Ready = "Api Ready";
            return Json(Ready, JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpPost]
        public JsonResult GET_municipality_update_filters()
        {
            JSONResponse response = new JSONResponse() { Status = a2m.Common.Responses.Response.Status.Ok };

            return Json(response, JsonRequestBehavior.AllowGet);  
        }
    }
}
