using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http;
using System.Web.Routing;
using DbUp;
using System.Configuration;
using a2m.Common;

namespace a2m
{
    public class A2MApplication : System.Web.HttpApplication
    {
        public static ILog Log;
        public static bool StartedSuccesfully = false;
        public static int ResultsPaginateSize = int.Parse(System.Configuration.ConfigurationManager.AppSettings["ResultsPaginateSize"]);

        protected void Application_Start()
        {
            try
            {
                AreaRegistration.RegisterAllAreas();
                FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
                RouteConfig.RegisterRoutes(RouteTable.Routes);
                BundleConfig.RegisterBundles(BundleTable.Bundles);
                log4net.Config.XmlConfigurator.Configure();
                Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
                GlobalConfiguration.Configure(WebApiConfig.Register);

                HttpConfiguration config = GlobalConfiguration.Configuration;
                config.Formatters.JsonFormatter.SerializerSettings.Formatting =
                    Newtonsoft.Json.Formatting.Indented;

                var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["a2mConnectionString"].ConnectionString;
                var ResultsPaginateSize = int.Parse(System.Configuration.ConfigurationManager.AppSettings["ResultsPaginateSize"]);


                BdUpLogger BdUpLogger = new BdUpLogger();
                
                var upgrader =
                    DeployChanges.To
                        .SqlDatabase(connectionString)
                        .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly()).LogTo(BdUpLogger)                        
                        .Build();

                var result = upgrader.PerformUpgrade();

                if (!result.Successful)
                {
                    Log.Debug("A2M Not started succesfully due dbUp problem");
                    StartedSuccesfully = false;
                }
                else
                {


                    Log.Debug("A2M started succesfully");
                    StartedSuccesfully = true;
                }
            }
            catch (Exception ex)
            {
                StartedSuccesfully = false;
                Log.Fatal("Unable to start A2M", ex);
            }

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            #if DEBUG
                        try
                        {
                            var routeData = RouteTable.Routes.GetRouteData(
                                new HttpContextWrapper(HttpContext.Current));
                            if (routeData == null) return;
                            string action;
                            try
                            {
                                action = routeData.GetRequiredString("action");
                            }
                            catch
                            {
                                action = string.Empty;
                            }
                            string controller;
                            try
                            {
                                controller = routeData.GetRequiredString("controller");
                            }
                            catch 
                            {
                                controller = string.Empty;
                            }

                            Log.Info(string.Format("Request url: {2}, attended by: {1},action:{0}", action, controller, System.Web.HttpContext.Current.Request.Url));
                        }
                        catch (Exception ex)
                        {
                             Log.Warn("Application_BeginRequest Error", ex);
                        }
            #endif

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var ex = Server.GetLastError();

            Log.Error("Application_Error", ex);

            var exception = ex as HttpException;

            if (exception != null)
            {
                /* #if LOCAL || DEBUG || TEST
                     Response.Redirect("error/" + exception.GetHttpCode());
                 #else
                     Response.Redirect("error/" + exception.GetHttpCode());
                 #endif*/
            }
        }
    }
}
