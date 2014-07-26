using System.ComponentModel.DataAnnotations;

namespace NavigationIdentity.Web.Models.Account
{
   public class VerifyTwoFactorCodeViewModel
   {
      public bool IsDemo { get; set; }
      public string DemoCode { get; set; }
      public string Provider { get; set; }

      [Display(Name = "Verification Code")]
      [Required(ErrorMessage = "{0} must be specified")]
      public string Code { get; set; }

      [Display(Name = "Remember browser?")]
      public bool RememberBrowser { get; set; }
   }
}