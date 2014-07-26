
namespace NavigationIdentity.Web.Models.Account
{
   public enum SignInStatus
   {
      Success,
      LockedOut,
      NotVerified,
      RequiresTwoFactorAuthentication,
      Failure
   }
}
