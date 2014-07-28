using System.Web.Optimization;

namespace NavigationIdentity.Web
{
   public class BundleConfig
   {
      // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkID=303951
      public static void RegisterBundles(BundleCollection bundles)
      {

         // Use the Development version of Modernizr to develop with and learn
         // from. Then, when you’re ready for production, use the build tool 
         // at http://modernizr.com to pick only the tests you need
         bundles.Add(new ScriptBundle("~/bundles/modernizr")
            .Include("~/Scripts/modernizr-*")
         );

         // Set EnableOptimizations to false for debugging. For more 
         // information, visit http://go.microsoft.com/fwlink/?LinkId=301862
         BundleTable.EnableOptimizations = true;


         #region CSS Bundles
         bundles.Add(new StyleBundle("~/Css/Bootstrap/bundle").Include(
            "~/Css/Bootstrap/bootstrap.css",
            "~/Css/BootstrapPlus.css"
         ));

         bundles.Add(new StyleBundle("~/Css/site").Include(
            "~/Css/Site.css"
         ));
         #endregion CSS Bundles


         #region JavaScript Bundles
         // Uncomment the following code to enable jQuery and Bootstrap mobile
         // bundles.Add(new ScriptBundle("~/script/site").Include(
         //    "~/Scripts/jquery-{version}.js",
         //    "~/Scripts/bootstrap.js"
         // ));
         #endregion JavaScript Bundles

      }
   }
}