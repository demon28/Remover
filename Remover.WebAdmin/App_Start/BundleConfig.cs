using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Remover.WebAdmin
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/css").Include(
                        "~/Content/assets/css/bootstrap.css",
                        "~/Content/assets/css/ace-*",
                        "~/Content/assets/css/ace.css",
                        "~/Content/components/font-awesome/css/font-awesome.css"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Content/components/jquery/dist/jquery.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Content/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/aceScript").Include(
                "~/Content/assets/js/src/ace.js",
                "~/Content/assets/js/src/elements.*",
                "~/Content/assets/js/src/ace.*"));

            bundles.Add(new ScriptBundle("~/bundles/pluginScripts").Include(
                "~/Content/components/datatables/media/js/jquery.dataTables.js",
                "~/Content/components/_mod/datatables/jquery.dataTables.bootstrap.js",
                "~/Content/components/datatables.net-buttons/js/buttons.*",
                "~/Content/components/datatables.net-buttons/js/dataTables.buttons.min.js",
                "~/Content/components/datatables.net-select/js/dataTables.select.min"));

            bundles.Add(new ScriptBundle("~/bundles/bootScripts").Include(
                "~/Content/Scripts/knockout-2.2.0.js",
                "~/Content/components/bootstrap/dist/js/bootstrap.js",
                "~/Content/Scripts/bootbox.min.js"));
        }
    }
}