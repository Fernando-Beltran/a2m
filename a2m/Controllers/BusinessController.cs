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
    public class BusinessController : Controller
    {
        public ActionResult Index(string municipality,string business)
        {
            try
            {
                Business currentBusiness = BussinessManager.GetBusinessFromMunicipalityNormalizedNameAndBusinessNormalizedNamed(municipality, business);
                if (currentBusiness == null) return View("Error");

                BusinessModel BusinessModel = new BusinessModel();
                BusinessModel.Business = currentBusiness;
                return View(BusinessModel);
            }
            catch (Exception ex)
            {
                a2m.A2MApplication.log.Error("BusinessController", ex);
                return View("Error");
            }
        }
	}
}