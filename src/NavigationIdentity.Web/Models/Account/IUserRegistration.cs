using NavigationIdentity.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace NavigationIdentity.Web.Models.Account
{
   public interface IUserRegistration
   {
      [Display(Name = "Username")]
      [Required(ErrorMessage = "{0} must be specified")]
      [StringLength(256, ErrorMessage = "{0} must not exceed {1} characters")]
      string UserName { get; set; }

      [Display(Name = "Email Address")]
      [Required(ErrorMessage = "{0} must be specified")]
      [EmailAddress(ErrorMessage = "Invalid email address")]
      string Email { get; set; }

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

      [Display(Name = "DoB")]
      [DataType(DataType.Date)]
      DateTime DateOfBirth { get; set; }
   }
}