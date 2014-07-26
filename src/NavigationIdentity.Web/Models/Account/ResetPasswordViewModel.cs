using System.ComponentModel.DataAnnotations;

namespace NavigationIdentity.Web.Models.Account
{
   public class ResetPasswordViewModel
   {
      [Display(Name = "Email Address")]
      [Required(ErrorMessage = "{0} must be specified")]
      [EmailAddress(ErrorMessage = "Invalid email address")]
      [StringLength(256, ErrorMessage = "{0} must not exceed {1} characters")]
      public string Email { get; set; }

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