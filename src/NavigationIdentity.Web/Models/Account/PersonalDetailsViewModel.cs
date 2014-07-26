using NavigationIdentity.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace NavigationIdentity.Web.Models.Account
{
   public class PersonalDetailsViewModel
   {

      [Display(Name = "Title")]
      [StringLength(64, ErrorMessage = "{0} must not exceed {1} characters")]
      public string Title { get; set; }

      [Display(Name = "First Name")]
      [StringLength(64, ErrorMessage = "{0} must not exceed {1} characters")]
      [Required(ErrorMessage = "{0} must be specified")]
      public string FirstName { get; set; }

      [Display(Name = "Last Name")]
      [StringLength(64, ErrorMessage = "{0} must not exceed {1} characters")]
      [Required(ErrorMessage = "{0} must be specified")]
      public string LastName { get; set; }

      [Display(Name = "Gender")]
      public Gender Gender { get; set; }

      [Display(Name = "DoB")]
      [DataType(DataType.Date)]
      public DateTime DateOfBirth { get; set; }

   }
}