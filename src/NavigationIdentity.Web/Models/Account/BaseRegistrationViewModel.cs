using NavigationIdentity.Models;
using System;

namespace NavigationIdentity.Web.Models.Account
{
   public class BaseUserRegistrationViewModel
      : IUserRegistration
   {
      public string UserName { get; set; }
      public string Email { get; set; }
      public string Title { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public Gender Gender { get; set; }
      public DateTime DateOfBirth { get; set; }

      public BaseUserRegistrationViewModel()
      {
         DateOfBirth = new DateTime(DateTime.Now.Year - 20, 1, 1).Date;
         Gender = Gender.Male;
      }

   }
}