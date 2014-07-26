using System.Web.Routing;

namespace NavigationIdentity.Web
{
   public static class RouteConfig
   {
      public static void RegisterRoutes(RouteCollection routes)
      {
         routes.MapPageRoute(
            "PageNotFound", 
            "PageNotFound", 
            "~/Views/Error/PageNotFound.aspx");

         routes.MapPageRoute(
            "ApplicationError",
            "ApplicationError",
            "~/Views/Error/ApplicationError.aspx");
      }
   }
}
