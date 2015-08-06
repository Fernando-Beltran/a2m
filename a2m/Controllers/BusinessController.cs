using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using a2mbl;
using a2m.Models;
using a2mbl.Managers;
using CustomExtensions;

namespace a2m.Controllers
{
    /// <summary>
    /// Controlador de negocios
    /// </summary>
    public class BusinessController : Controller
    {
        /// <summary>
        /// Obtiene un negocio
        /// </summary>
        /// <param name="municipality">Municipio</param>
        /// <param name="business">Negocio</param>
        /// <returns>Vista de la ficha de un municipio</returns>
        public ActionResult Index(string municipality,string business)
        {
            try
            {
                Business currentBusiness = null;
                //Business currentBusiness =  BussinessManager.GetBusinessFromMunicipalityNormalizedNameAndBusinessNormalizedNamed(municipality, business);
                if (currentBusiness == null) return View("Error");

                BusinessModel BusinessModel = new BusinessModel();
                BusinessModel.Business = currentBusiness;
                return View(BusinessModel);
            }
            catch (Exception ex)
            {
                a2m.A2MApplication.Log.Error("BusinessController", ex);
                return View("Error");
            }
        }
	}
}