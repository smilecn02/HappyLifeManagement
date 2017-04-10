﻿using System.Web;
using System.Web.Optimization;

namespace HappyLifeManagement
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/summernote/summernote.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/moment.min.js",
                      "~/Scripts/bootstrap-datetimepicker.min.js",
                      "~/Scripts/app/datepicker.js",
                      "~/Scripts/app/home-index.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-datetimepicker.css",
                      "~/Content/font-awesome.css",
                      "~/Content/summernote.css",
                      "~/Content/site.css"));
        }
    }
}
