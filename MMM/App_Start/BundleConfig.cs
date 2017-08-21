using System.Web;
using System.Web.Optimization;

namespace MMM
{
    public class BundleConfig
    {

        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = true;

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

            bundles.Add(new ScriptBundle("~/bundles/load-transactions").Include(
                "~/Scripts/Custom/load-transactions.js",
                "~/Scripts/Custom/edit-accountbalance-bankaccount.js",
                "~/Scripts/Custom/search-transaction.js"));

            bundles.Add(new ScriptBundle("~/bundles/add-transaction").Include(
                "~/Scripts/Custom/add-transaction.js"));

            bundles.Add(new ScriptBundle("~/bundles/edit-transaction").Include(
                "~/Scripts/Custom/edit-transaction.js"));

            bundles.Add(new ScriptBundle("~/bundles/delete-transaction").Include(
                "~/Scripts/Custom/delete-transaction.js"));

            bundles.Add(new ScriptBundle("~/bundles/details-transaction").Include(
                "~/Scripts/Custom/details-transaction.js"));

            bundles.Add(new ScriptBundle("~/bundles/load-transaction-to-modal").Include(
                "~/Scripts/Custom/get-transaction.js",
                "~/Scripts/Custom/load-modal.js",
                "~/Scripts/Custom/paging-system.js"));
        }
    }
}
