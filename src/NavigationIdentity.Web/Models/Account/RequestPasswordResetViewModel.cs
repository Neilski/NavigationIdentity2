using System.ComponentModel.DataAnnotations;

namespace NavigationIdentity.Web.Models.Account
{
   public class RequestPasswordResetViewModel
   {
      [Display(Name = "Email Address")]
      [Required(ErrorMessage = "{0} must be specified")]
      [EmailAddress(ErrorMessage = "Invalid email address")]
      [StringLength(256, ErrorMessage = "{0} must not exceed {1} characters")]
      public string Email { get; set; }
   }
}