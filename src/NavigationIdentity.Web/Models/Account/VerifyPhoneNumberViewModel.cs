using System.ComponentModel.DataAnnotations;

namespace NavigationIdentity.Web.Models.Account
{
   public class VerifyPhoneNumberViewModel
   {
      // These fields are used for demonstration purposes only and should
      // be removed from the production build
      public bool IsDemo { get; set; }
      public string DemoCode { get; set; }


      [Display(Name = "Phone Number")]
      [Required(ErrorMessage = "{0} must be specified")]
      [StringLength(256, ErrorMessage = "{0} must not exceed {1} characters")]
      public string PhoneNumber { get; set; }

      [Display(Name = "Code")]
      [Required(ErrorMessage = "{0} must be specified")]
      [StringLength(256, ErrorMessage = "{0} must not exceed {1} characters")]
      public string Code { get; set; }
   }
}