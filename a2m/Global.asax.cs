using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace a2m
{
    public class A2MApplication : System.Web.HttpApplication
    {
        public static ILog Log;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            log4net.Config.XmlConfigurator.Configure();
            Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            Log.Debug("Application_Start");
        }
    }
}
