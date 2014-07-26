using System;
using System.ComponentModel.DataAnnotations;
using NavigationIdentity.Models.Interfaces;

namespace NavigationIdentity.Models
{
   [MetadataType(typeof(IUserDetails))]
   public class UserDetails 
      : IUserDetails
   {

      #region CTOR
      public UserDetails()
      {
         DateOfBirth = new DateTime(DateTime.Now.Year - 20, 1, 1).Date;
         Gender = Gender.Male;
      }
      #endregion CTOR

      public string Id { get; set; }
      public string Title { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public Gender Gender { get; set; }
      public DateTime DateOfBirth { get; set; }


      // Navigation Properties
      public virtual ApplicationUser User { get; set; }

   }
}
