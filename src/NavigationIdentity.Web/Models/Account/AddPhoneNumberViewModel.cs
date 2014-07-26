using System.ComponentModel.DataAnnotations;

namespace NavigationIdentity.Web.Models.Account
{
   public class AddPhoneNumberViewModel
   {
      [Display(Name = "Phone Number")]
      [Required(ErrorMessage = "{0} must be specified")]
      [StringLength(256, ErrorMessage = "{0} must not exceed {1} characters")]
      public string PhoneNumber { get; set; }
   }
}