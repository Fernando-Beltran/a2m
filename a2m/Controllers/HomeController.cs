using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using a2mbl;
using a2mbl.Managers;
using a2m;
using a2m.Models;


namespace a2m.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                HomeModel HomeModel = new HomeModel();
                HomeModel.Municipalities = MunicipalityManager.getAllMunicipalities();
                return View(HomeModel);
            }
            catch (Exception ex) {
                a2m.MvcApplication.log.Error("HomeController", ex);
                return View();
            }
        }


        public ActionResult About()
        {
           
            return View();
        }

        public ActionResult Access()
        {

            return View();
        }

        public ActionResult Help()
        {

            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }
    }
}