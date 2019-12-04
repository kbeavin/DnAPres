using System.Web;
using System.Web.Optimization;

namespace DnAPresa.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Content/Scripts/jquery/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Content/Scripts/jquery-validate/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Content/Scripts/modernizr/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/Scripts/bootstrap/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/dataTables").Include(
                      "~/Content/packages/DataTables/js/jquery.dataTables.js",
                      "~/Content/packages/DataTables/js/dataTables.bootstrap.js",
                      "~/Content/packages/DataTables/js/dataTables.rowGroup.js"));

            bundles.Add(new ScriptBundle("~/bundles/global").Include(
                        "~/Content/Scripts/global/app.js",
                        "~/Content/Scripts/global/global.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap/bootstrap.css",
                      "~/Content/packages/DataTables/css/jquery.dataTables.css",
                      "~/Content/packages/DataTables/css/dataTables.bootstrap.css",
                      "~/Cotent/packages/DataTables/css/rowGroup.dataTables.css",
                      "~/Content/main/main.css"));
        }
    }
}
