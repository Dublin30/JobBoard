using System.Web.Optimization;

namespace IdentitySample
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/bootstrap.min.js",
                        "~/Scripts/jquery.min.js",
                        "~/Scripts/main.js",
                        "~/Scripts/skel.min.js",
                        "~/Scripts/util.js"
                        ));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap.css",
                      "~/Content/css/bootstrap.min.css",
                      "~/Content/css/font-awesome.min.css",
                      "~/Content/css/main.css"
                      ));
        }
    }
}
