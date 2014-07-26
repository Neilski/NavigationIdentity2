using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NavigationIdentity.Web.IdentityStartup))]
namespace NavigationIdentity.Web
{
   // Bootstrap the ASP.net Identity Authorisation configuration
   public partial class IdentityStartup
   {
      public void Configuration(IAppBuilder app)
      {
         ConfigureAuth(app);
      }
   }
}
