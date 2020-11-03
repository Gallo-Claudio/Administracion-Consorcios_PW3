using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace WebApp.App_Start
{
    public class BundleConfig
    {

        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-3.*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/dataTables").Include(
                        "~/Scripts/DTables/datatables.min.js",
                        "~/Scripts/DTables/ListadoTabla.js"));

            bundles.Add(new ScriptBundle("~/bundles/sweetAlert").Include(
                        "~/Scripts/sweetAlert/sweetalert2@10.js",
                        "~/Scripts/sweetAlert/promise-polyfill.js"));




            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/dataTables").Include("~/Content/DTables/datatables.min.css"));




            BundleTable.EnableOptimizations = true;
        }
    }
}