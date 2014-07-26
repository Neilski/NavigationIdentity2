
namespace NavigationIdentity.Web.Models.Account
{
   public class RegistrationEmailVerificationViewModel
   {
      public bool Success { get; set; }
      public bool Failure { get { return !Success; } }
      public string StatusMessage { get; set; }
   }
}