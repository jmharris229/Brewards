﻿using System.Web;
using System.Web.Optimization;

namespace brewards
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/angular-material.min.css",
                      "~/Content/font-awesome.min.css",
                      "~/fonts/fontawesome-webfont.woff",
                      "~/fonts/fontawesome-webfont.woff2",
                      "~/fonts/fontawesome-glyphicons-halflings-regular.ttf"
                      ));
            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                "~/Scripts/angular.min.js",
                "~/Scripts/angular-route.min.js",
                "~/Scripts/angular-material/angular-material.min.js",
                "~/Scripts/angular-animate/angular-animate.min.js",
                "~/Scripts/angular-aria/angular-aria.min.js",
                "~/Scripts/app.js",
                "~/Scripts/addPunchCtrl.js",
                "~/Scripts/rewardsCtrl.js",
                "~/Scripts/purchasesCtrl.js",
                "~/Scripts/brewNewsCtrl.js",
                "~/Scripts/authService.js",
                "~/Scripts/locationService.js",
                "~/Scripts/nearbyBreweriesCtrl.js",
                "~/Scripts/homeCtrl.js"
                ));
        }
    }
}
