using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace NavigationIdentity.Models.Extensions
{
   public static class ApplicationUserExtension
   {
      public static ClaimsIdentity 
      GenerateUserIdentity(this ApplicationUser user, ApplicationUserManager manager)
      {
         // Note the authenticationType must match the one defined in 
         // CookieAuthenticationOptions.AuthenticationType
         var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

         return userIdentity;
      }

      public static Task<ClaimsIdentity> 
      GenerateUserIdentityAsync(this ApplicationUser user, ApplicationUserManager manager)
      {
         return Task.FromResult(user.GenerateUserIdentity(manager));
      }
   }
}
