using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace NavigationIdentity.Models.Interfaces
{
   public interface IApplicationUser
   {
      [Display(Name = "UserId")]
      [StringLength(128, ErrorMessage = "{0} must not exceed {1} characters")]
      string Id { get; set; }

      [Display(Name = "Username")]
      [Required(ErrorMessage = "{0} must be specified")]
      [StringLength(256, ErrorMessage = "{0} must not exceed {1} characters")]
      string UserName { get; set; }

      [Display(Name = "Email Address")]
      [Required(ErrorMessage = "{0} must be specified")]
      [EmailAddress(ErrorMessage = "Invalid email address")]
      [StringLength(256, ErrorMessage = "{0} must not exceed {1} characters")]
      string Email { get; set; }

      [Display(Name = "Email Confirmed?")]
      bool EmailConfirmed { get; set; }

      [Display(Name = "Password Hash")]
      string PasswordHash { get; set; }

      [Display(Name = "Security Stamp")]
      string SecurityStamp { get; set; }

      [Display(Name = "Telephone Number")]
      string PhoneNumber { get; set; }

      [Display(Name = "Telephone Number Confirmed?")]
      bool PhoneNumberConfirmed { get; set; }

      [Display(Name = "Two Factor Authentication Enabled?")]
      bool TwoFactorEnabled { get; set; }

      [Display(Name = "Lockout End Date/Time")]
      DateTime? LockoutEndDateUtc { get; set; }

      [Display(Name = "Lockout Enabled?")]
      bool LockoutEnabled { get; set; }

      [Display(Name = "Access Failure Count")]
      int AccessFailedCount { get; set; }


      // Navigation Properties
      [Display(Name = "Roles")]
      ICollection<IdentityUserRole> Roles { get; }

      [Display(Name = "Claims")]
      ICollection<IdentityUserClaim> Claims { get; }

      [Display(Name = "Logins")]
      ICollection<IdentityUserLogin> Logins { get; }

      [Display(Name = "User Details")]
      UserDetails UserDetails { get; set; }
   }
}