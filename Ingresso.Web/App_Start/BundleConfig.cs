using System.Web.Optimization;

namespace Ingresso.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/bundle-jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/bundle-jqueryval").Include(
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/jquery.maskedinput.js"));

            bundles.Add(new ScriptBundle("~/bundles/bundle-modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bundle-bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/moment-with-locales.js",
                      "~/Scripts/moment-pt-br.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/bootstrap-datetimepicker.js",
                      "~/Scripts/ingresso.js"));

            bundles.Add(new StyleBundle("~/Content/bundle-css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-datetimepicker.css",
                      "~/Content/site.css"));
        }
    }
}
