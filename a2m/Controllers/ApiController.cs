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
using a2m.Models;
using a2mbl;
using a2mbl.Managers;
using a2mbl.Common;


namespace a2m.Controllers
{
    /// <summary>
    /// Controlador para el API de JSON
    /// </summary>
    public class ApiController : BaseController  
    {
        [System.Web.Http.HttpPost]
        public JsonResult Index()
        {
            string Ready = "Api Ready";
            return Json(Ready, JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpPost]
        public JsonResult GET_municipality_update_filters(RequestBusinessFilter request)
        {
            try
            {
                BusinessResultResponse response = new BusinessResultResponse() { Status = a2m.Common.Responses.Response.Status.Ok };
                Municipality currentMunicipality = MunicipalityManager.getMunicipalityByNormalizedName(request.CurrentMunicipality);
                if (currentMunicipality == null){
                    a2m.A2MApplication.Log.Error("BusinessController unable to found municipality " + request.CurrentMunicipality);
                    JSONResponse responseError = new JSONResponse() { Status = a2m.Common.Responses.Response.Status.Error };
                    return Json(responseError, JsonRequestBehavior.AllowGet);
                }
                MunicipalityModel MunicipalityModel = new MunicipalityModel();
                MunicipalityModel.Municipality = currentMunicipality;
                MunicipalityModel.CurrentPage = request.CurrentPage;
                //TODO FILTERING
                BussinessManager BussinessManager = new BussinessManager();
                MunicipalityModel.BusinessList = BussinessManager.GetBusinessFromMunicipalityIdAndFilters(request.toBusinesFilter(), a2m.A2MApplication.ResultsPaginateSize);

                response.ResultHtmlView = RenderRazorViewToString("~/Views/Municipality/MunicipalitySearchResult.cshtml", MunicipalityModel);
                response.PageSize = a2m.A2MApplication.ResultsPaginateSize;
                response.TotalResult = MunicipalityModel.BusinessList.Count;
                response.NextPage = request.CurrentPage + 1;
                return Json(response, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                a2m.A2MApplication.Log.Error("BusinessController", ex);
                JSONResponse response = new JSONResponse() { Status = a2m.Common.Responses.Response.Status.Error };
                return Json(response, JsonRequestBehavior.AllowGet);

            }
        }

        [System.Web.Http.HttpPost]
        public JsonResult GET_municipality_get_results(RequestBusinessFilter request)
        {
            try
            {
                BusinessResultResponse response = new BusinessResultResponse() { Status = a2m.Common.Responses.Response.Status.Ok };
                Municipality currentMunicipality = MunicipalityManager.getMunicipalityByNormalizedName(request.CurrentMunicipality);
                if (currentMunicipality == null)
                {
                    a2m.A2MApplication.Log.Error("BusinessController unable to found municipality " + request.CurrentMunicipality);
                    JSONResponse responseError = new JSONResponse() { Status = a2m.Common.Responses.Response.Status.Error };
                    return Json(responseError, JsonRequestBehavior.AllowGet);
                }
                MunicipalityModel MunicipalityModel = new MunicipalityModel();
                MunicipalityModel.Municipality = currentMunicipality;
                MunicipalityModel.CurrentPage = request.CurrentPage;
                //TODO FILTERING
                request.CurrentBussinessId = currentMunicipality.Pk_Municipality;
                BusinesFilter BusinesFilter = request.toBusinesFilter();

                BussinessManager BussinessManager = new BussinessManager();
                MunicipalityModel.BusinessList = BussinessManager.GetBusinessFromMunicipalityIdAndFilters(BusinesFilter, a2m.A2MApplication.ResultsPaginateSize);

                response.ResultHtmlView = RenderRazorViewToString("~/Views/Municipality/MunicipalitySearchResult.cshtml", MunicipalityModel);
                response.PageSize = a2m.A2MApplication.ResultsPaginateSize;
                response.TotalResult = MunicipalityModel.BusinessList.Count;
                response.NextPage = request.CurrentPage + 1;
                return Json(response, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                a2m.A2MApplication.Log.Error("BusinessController", ex);
                JSONResponse response = new JSONResponse() { Status = a2m.Common.Responses.Response.Status.Error };
                return Json(response, JsonRequestBehavior.AllowGet);

            }
        }
    }
}
