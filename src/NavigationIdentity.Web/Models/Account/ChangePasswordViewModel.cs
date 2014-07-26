using System.ComponentModel.DataAnnotations;

namespace NavigationIdentity.Web.Models.Account
{
   public class ChangePasswordViewModel
   {
      [Required]
      [DataType(DataType.Password)]
      [Display(Name = "Current Password")]
      public string CurrentPassword { get; set; }

      [Required]
      [StringLength(100, ErrorMessage = "{0} must be at least {2} characters long.", MinimumLength = 8)]
      [DataType(DataType.Password)]
      [Display(Name = "New Password")]
      public string NewPassword { get; set; }

      [DataType(DataType.Password)]
      [Display(Name = "Confirm New password")]
      [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
      public string ConfirmPassword { get; set; }
   }
}