﻿using a2mbl.bl.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace a2m.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            BussinessManager.ValidateLogin("aaa", "aaa");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}