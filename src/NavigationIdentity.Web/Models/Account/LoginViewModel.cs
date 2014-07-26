using System.ComponentModel.DataAnnotations;

namespace NavigationIdentity.Web.Models.Account
{
   public class LoginViewModel
   {
      public string StatusText { get; set; }
      public bool Success { get; set; }
      public bool Failure { get { return !Success; }}

      [Required]
      [Display(Name = "User name")]
      public string UserName { get; set; }

      [Required]
      [DataType(DataType.Password)]
      [Display(Name = "Password")]
      public string Password { get; set; }

      [Display(Name = "Remember me?")]
      public bool RememberMe { get; set; }


      public LoginViewModel()
      {
         Success = true;
      }

   }
}