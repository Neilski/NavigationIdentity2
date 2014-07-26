using Microsoft.AspNet.Identity;
using Navigation;
using NavigationIdentity.Models;
using NavigationIdentity.Web.Models.Account;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web;
using System.Web.UI.WebControls;

namespace NavigationIdentity.Web.Controllers
{
   /// <summary>
   /// This module defines helper methods used by the main AccountController
   /// action methods
   /// </summary>
   public partial class AccountController
   {
      private static string
         GetStatusMessage(ManageMessageId? message)
      {
         return
            message == ManageMessageId.AccountVerified
            ? "Your account has been verified."
            : message == ManageMessageId.ChangePasswordSuccess
            ? "Your password has been changed."
            : message == ManageMessageId.UserDetailsUpdateSuccess
            ? "Your personal details have been updated."
            : message == ManageMessageId.SetPasswordSuccess
            ? "Your password has been set."
            : message == ManageMessageId.RemoveLoginSuccess
            ? "The external login was removed."
            : message == ManageMessageId.AddPhoneSuccess
            ? "The phone number was successfully verified."
            : message == ManageMessageId.RemovePhoneSuccess
            ? "The phone number was removed."
            : message == ManageMessageId.Error
            ? "An error has occurred."
            : message ==
            ManageMessageId.TwoFactorAuthEnabledSuccess
            ? "Two-Factor Authentication has been enabled"
            : message ==
            ManageMessageId
            .TwoFactorAuthDisabledSuccess
            ? "Two-Factor Authentication has been disabled"
            : message ==
            ManageMessageId
            .RememberTwoFactorBrowserEnabledSuccess
            ? "Remember Two-Factor Browser has been enabled"
            : message ==
            ManageMessageId
            .RememberTwoFactorBrowserDisabledSuccess
            ? "Remember Two-Factor Browser has been disabled"
            : "";
      }


      private static void
         AddErrors(IdentityResult result, ModelMethodContext context)
      {
         foreach (var error in result.Errors)
         {
            context.ModelState.AddModelError("", error);
         }
      }


      private static bool
         IsLocalUrl(string url)
      {
         return (
            !String.IsNullOrEmpty(url) && (
               (url[0] == '/' && (
                  url.Length == 1 || (url[1] != '/' && url[1] != '\\')
                  )) || (url.Length > 1 && url[0] == '~' && url[1] == '/')
               ));
      }


      private static string
         GetResetPasswordRedirectUrl(string code)
      {
         var link = StateController.GetNavigationLink(
            "ResetPassword",
            new NavigationData
            {
               {CodeKey, code}
            });

         return GetWebSiteAddress() + link;
      }


      private static string
         GetEmailVerificationRedirectUrl(
         string code, 
         string userId)
      {
         var link = StateController.GetNavigationLink(
            "RegistrationEmailVerification",
            new NavigationData
            {
               { CodeKey, code },
               { UserIdKey, userId }
            });

         return GetWebSiteAddress() + link;
      }


      private void
         ExternalLoginFailRedirect()
      {
         if (_context.User.Identity.IsAuthenticated)
         {
            StateController.Navigate("Manage");
         }
         StateController.Navigate("Login");
      }


      private void
         RedirectToLocal()
      {
         if (IsLocalUrl(StateContext.Bag.ReturnUrl))
         {
            _response.Redirect(StateContext.Bag.ReturnUrl);
         }
         else
         {
            StateController.Navigate("Home");
         }
      }


      private void
         RedirectToLogin(string returnUrl)
      {
         StateController.Navigate(
            "Login",
            new NavigationData
            {
               {"ReturnUrl", returnUrl}
            });
      }

      private void
         RedirectToManager(ManageMessageId message)
      {
         StateController.Navigate(
            "Manage",
            new NavigationData
            {
               {"message", message}
            });
      }


      public static string
         GetWebSiteAddress()
      {
         // Scheme = "http"
         // Host = "localhost"
         // Port = 57988
         // Authority = "localhost:57988
         var url = HttpContext.Current.Request.Url;
         return url.Scheme + "://" + url.Authority;
      }


      public IEnumerable<ListItem>
         GetGenderList()
      {
         var genderType = typeof (Gender);
         var genders = new List<ListItem>();

         foreach (int value in Enum.GetValues(genderType))
         {
            var text = Enum.GetName(genderType, value);
            genders.Add(new ListItem
            {
               Text = text,
               Value = value.ToString(CultureInfo.InvariantCulture)
            });
         }
         return genders;
      }


      private static ApplicationUser
         CreateUserFromRegistration(IUserRegistration model)
      {
         return new ApplicationUser
         {
            UserName = model.UserName,
            Email = model.Email,
            UserDetails = new UserDetails
            {
               Title = model.Title,
               FirstName = model.FirstName,
               LastName = model.LastName,
               Gender = model.Gender,
               DateOfBirth = model.DateOfBirth
            }
         };
      }
   }
}