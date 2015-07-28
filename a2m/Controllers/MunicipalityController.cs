using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using a2m.Models;
using a2mbl;
using a2mbl.Managers;
using CustomExtensions;

namespace a2m.Controllers
{
    public class MunicipalityController : Controller
    {
        public ActionResult Index(string municipality)
        {
            try
            {
                if (municipality.IsNullOrEmpty()) return View("Error");
                Municipality currentMunicipality = MunicipalityManager.getMunicipalityByNormalizedName(municipality);
                if (currentMunicipality == null) return View("Error");
                MunicipalityModel MunicipalityModel = new MunicipalityModel();
                MunicipalityModel.Municipality = currentMunicipality;
                MunicipalityModel.BusinessList = BussinessManager.GetBusinessFromMunicipalityId(currentMunicipality.Pk_Municipality);

                return View(MunicipalityModel);
            }
            catch (Exception ex)
            {
                a2m.A2MApplication.log.Error("MunicipalityController", ex);
                return View("Error");
            }
        }
	}
}