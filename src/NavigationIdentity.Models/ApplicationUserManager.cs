using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNet.Identity;

namespace NavigationIdentity.Models
{
   public class ApplicationUserManager
      : UserManager<ApplicationUser>
   {

      // Set to true to force the user to verify their email account
      // before being allowed to login
      public bool ForceEmailVerification { get; set; }


      #region CTORs
      public ApplicationUserManager(IUserStore<ApplicationUser> store)
         : base(store)
      {
      }
      #endregion CTORs

   }
}
