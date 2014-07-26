using System.ComponentModel.DataAnnotations;

namespace NavigationIdentity.Web.Models.Account
{
   [MetadataType(typeof(IUserRegistration))]
   public class RegisterViewModel
      : BaseUserRegistrationViewModel
   {

      [Required]
      [StringLength(100, ErrorMessage = "{0} must be at least {2} characters long.", MinimumLength = 8)]
      [DataType(DataType.Password)]
      [Display(Name = "Password")]
      public string Password { get; set; }

      [DataType(DataType.Password)]
      [Display(Name = "Confirm password")]
      [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
      public string ConfirmPassword { get; set; }

   }
}