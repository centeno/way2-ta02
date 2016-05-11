using System.Diagnostics.CodeAnalysis;
using System.Web.Optimization;

namespace way2_ta02
{
    [ExcludeFromCodeCoverage]
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css/app").Include(
                        "~/Content/css/bootstrap.css",
                        "~/Content/css/prettify.css",
                        "~/Content/css/flat-ui.css",
                        "~/Content/css/fancybox.css",
                        "~/Content/css/default.css"));

            bundles.Add(new StyleBundle("~/Content/js/app").Include(
                        "~/Content/js/jquery-1.8.3.min.js",
                        "~/Content/js/bootstrap.min.js",
                        "~/Content/js/bootstrap-select.js",
                        "~/Content/js/prettify.js",
                        "~/Content/js/fancybox.js",
                        "~/Content/js/jquery.unobtrusive-ajax.min.js",
                        "~/Content/js/default.js"));


            BundleTable.EnableOptimizations = true;
        }
    }
}
