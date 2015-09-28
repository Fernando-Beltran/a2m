﻿using System.Web;
using System.Web.Optimization;

namespace a2m
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Content/external/js/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Content/external/js/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Content/external/js/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/a2m").Include(
                       "~/Content/a2m/js/a2m.common.js",
                       "~/Content/a2m/js/a2m.enums.js",
                       "~/Content/a2m/js/a2m.properties.js",
                       "~/Content/a2m/js/a2m.utils.js",
                       "~/Content/a2m/js/a2m.cookie.js",
                       "~/Content/a2m/js/a2m.storage.js",
                       "~/Content/a2m/js/a2m.request.js",
                       "~/Content/a2m/js/a2m.municipality.js"
                       ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/external/js/bootstrap.js",
                      "~/Content/external/js/respond.js"));

            bundles.Add(new StyleBundle("~/css/common").Include(
                      "~/Content/external/css/bootstrap.css",
                      "~/Content/a2m/css/reset.css",
                      "~/Content/a2m/css/generic.css"
                  ));
            
            bundles.Add(new StyleBundle("~/css/list").Include(
                      "~/Content/external/css/list.css"));

            bundles.Add(new StyleBundle("~/css/basket").Include(
                      "~/Content/external/css/basket.css"));

            bundles.Add(new StyleBundle("~/css/product").Include(
                      "~/Content/external/css/product.css"));


        }
    }
}
