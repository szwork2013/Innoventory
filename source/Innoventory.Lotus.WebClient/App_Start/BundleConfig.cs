﻿using System.Web;
using System.Web.Optimization;

namespace Innoventory.Lotus.WebClient
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
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/Scripts/angular.min.js",
                        "~/Scripts/angular.min.js.map"));


            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                       "~/Scripts/angular.min.js",
                       "~/Scripts/angular.min.js.map"));

            bundles.Add(new ScriptBundle("~/bundles/angular-ui").IncludeDirectory(
                            "~/Scripts/angular-ui", "*.js", true));

            bundles.Add(new ScriptBundle("~/bundles/custom-scripts").IncludeDirectory(
                            "~/Scripts/custom-scripts", "*.js", true));

        }
    }
}
