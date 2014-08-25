using System.Web.Optimization;

namespace BngMvcSample
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/Site.css"));

            bundles.Add(new ScriptBundle("~/Scripts").Include(
                "~/Scripts/jquery-2.1.1.min.js",
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/angular.min.js"));
        }
    }
}