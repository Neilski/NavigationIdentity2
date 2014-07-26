
namespace NavigationIdentity.Web.Models.Account
{
   public class ManageViewModel
   {
      public bool HasMessage { get; set; }
      public bool Error { get; set; }
      public bool Success { get { return !Error; } }
      public string StatusMessage { get; set; }
      public string UserName { get; set; }
      public string Email { get; set; }
      public bool HasUserDetails { get; set; }
      public bool IsEmailConfirmed { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public bool UserNameEqualsEmail { get; set; }
   }
}