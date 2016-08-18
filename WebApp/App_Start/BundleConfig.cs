using System.Web;
using System.Web.Optimization;

namespace WebApp
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
            // start admin css and js
            bundles.Add(new StyleBundle("~/Content/AdminCss").Include(
                     "~/Content/Admin/css/bootstrap.min.css",
                     "~/Content/Admin/css/style.css",
                     "~/Content/Admin/css/font-awesome.css",
                     "~/Content/Admin/css/icon-font.min.css",
                     "~/Content/Admin/css/animate.css",
                     "~/Scripts/media/css/jquery.dataTables.css",
                     "~/Content/Admin/css/Customize.css"));

            bundles.Add(new ScriptBundle("~/Content/AdminJs").Include(
                    "~/Content/Admin/js/Jquery.js",
                    "~/Content/Admin/bootstrap/js/bootstrap.min.js",
                    "~/Content/Admin/js/custom.js"));
            // end admin css and js

            // start Homepage css and js
            bundles.Add(new StyleBundle("~/Content/HomepageCss").Include(
                     "~/Content/Customer/css/bootstrap.css",
                     "~/Content/Customer/css/style.css",
                     "~/Content/Customer/css/font-awesome.css"));

            bundles.Add(new ScriptBundle("~/Content/HomepageJs").Include(
                    "~/Content/Customer/js/jquery.min.js",
                    "~/Content/Customer/js/bootstrap-3.1.1.min.js",
                    "~/Content/Customer/js/simpleCart.min.js"));

            bundles.Add(new ScriptBundle("~/Content/HomepageJsFooter").Include(
                    "~/Content/Customer/js/CustomizeJsHomepage.js"));
            // end Homepage css and js
            /*<!-- //Custom Theme files -->
                <link href="css/bootstrap.css" type="text/css" rel="stylesheet" media="all">
                <link href="css/style.css" type="text/css" rel="stylesheet" media="all">
                <!-- js -->
                <script src="js/jquery.min.js"></script>
                <script type="text/javascript" src="js/bootstrap-3.1.1.min.js"></script>
                <!-- //js -->
                <!-- cart -->
                <script src="js/simpleCart.min.js"> </script>*/
        }
    }
}

