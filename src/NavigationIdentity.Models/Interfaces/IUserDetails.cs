using System;
using System.ComponentModel.DataAnnotations;

namespace NavigationIdentity.Models.Interfaces
{
   public interface IUserDetails
   {
      [Display(Name = "UserId")]
      string Id { get; set; }

      [Display(Name = "Title")]
      [StringLength(64, ErrorMessage = "{0} must not exceed {1} characters")]
      string Title { get; set; }

      [Display(Name = "First Name")]
      [StringLength(64, ErrorMessage = "{0} must not exceed {1} characters")]
      [Required(ErrorMessage = "{0} must be specified")]
      string FirstName { get; set; }

      [Display(Name = "Last Name")]
      [StringLength(64, ErrorMessage = "{0} must not exceed {1} characters")]
      [Required(ErrorMessage = "{0} must be specified")]
      string LastName { get; set; }

      [Display(Name = "Gender")]
      Gender Gender { get; set; }

      [Display(Name = "Date of Birth")]
      [DataType(DataType.Date)]
      DateTime DateOfBirth { get; set; }


      // Navigation Properties
      [Display(Name = "User")]
      ApplicationUser User { get; set; }

   }
}