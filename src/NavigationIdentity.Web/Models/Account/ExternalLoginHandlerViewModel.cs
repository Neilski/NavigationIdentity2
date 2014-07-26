using System.ComponentModel.DataAnnotations;

namespace NavigationIdentity.Web.Models.Account
{
   [MetadataType(typeof(IUserRegistration))]
   public class ExternalLoginHandlerViewModel 
      : BaseUserRegistrationViewModel
   {

      [Display(Name = "Provider Name")]
      public string ProviderName { get; set; }

   }
}