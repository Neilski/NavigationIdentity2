using System.Configuration;

namespace NavigationIdentity.Web.Services
{
   public static class ApplicationService
   {
      public static readonly string ApplicationName;

      #region CTORs
      static ApplicationService()
      {
         ApplicationName = ConfigurationManager
            .AppSettings["ApplicationName"] ?? "Unnamed Application";
      }
      #endregion CTORs
   }
}