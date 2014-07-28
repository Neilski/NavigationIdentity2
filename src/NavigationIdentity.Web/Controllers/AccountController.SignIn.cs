using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using NavigationIdentity.Models;
using NavigationIdentity.Models.Extensions;
using NavigationIdentity.Web.Models.Account;
using System;
using System.Security.Claims;
using System.Threading.Tasks;


namespace NavigationIdentity.Web.Controllers
{
   /// <summary>
   /// This module contains SignIn specific helper methods for the 
   /// AccountController class
   /// </summary>
   public partial class AccountController
   {

      public ApplicationUser
         GetCurrentUser()
      {
         var userId = _context.User.Identity.GetUserId();
         if (userId == null) return null;
         return _userManager.FindById(userId);
      }


      public string
         GetVerifiedUserId()
      {
         var result = Task.Run(
            async () =>
               await
                  _authenticationManager.AuthenticateAsync(
                     DefaultAuthenticationTypes.TwoFactorCookie)).Result;

         if ((result != null) && (result.Identity != null) &&
             (!String.IsNullOrEmpty(result.Identity.GetUserId())))
         {
            return result.Identity.GetUserId();
         }

         return null;
      }


      public bool HasBeenVerified()
      {
         return GetVerifiedUserId() != null;
      }


      public void
         SignIn(
         ApplicationUser user,
         bool isPersistent,
         bool rememberBrowser)
      {
         // Clear any partial cookies from external or two-factor partial 
         // sign-ins
         _authenticationManager.SignOut(
            DefaultAuthenticationTypes.ExternalCookie,
            DefaultAuthenticationTypes.TwoFactorCookie
            );

         var userIdentity = user.GenerateUserIdentity(_userManager);

         if (rememberBrowser)
         {
            var rememberBrowserIdentity = _authenticationManager
               .CreateTwoFactorRememberBrowserIdentity(user.Id);

            _authenticationManager.SignIn(
               new AuthenticationProperties
               {
                  IsPersistent = isPersistent
               }, userIdentity, rememberBrowserIdentity);
         }
         else
         {
            _authenticationManager.SignIn(
               new AuthenticationProperties
               {
                  IsPersistent = isPersistent
               }, userIdentity);
         }
      }


      public SignInStatus
         TwoFactorSignIn(
         string provider,
         string code,
         bool isPersistent,
         bool rememberBrowser)
      {
         var userId = GetVerifiedUserId();
         if (userId == null)
         {
            return SignInStatus.Failure;
         }
         var user = _userManager.FindById(userId);
         if (user == null)
         {
            return SignInStatus.Failure;
         }
         if (_userManager.IsLockedOut(user.Id))
         {
            return SignInStatus.LockedOut;
         }
         if (_userManager.VerifyTwoFactorToken(user.Id, provider, code))
         {
            // When token is verified correctly, clear the access failed count
            // used for lockout
            _userManager.ResetAccessFailedCount(user.Id);
            SignIn(user, isPersistent, rememberBrowser);
            return SignInStatus.Success;
         }
         // If the token is incorrect, record the failure which also may cause
         // the user to be locked out
         _userManager.AccessFailed(user.Id);
         return SignInStatus.Failure;
      }


      public SignInStatus
         ExternalSignIn(
         ExternalLoginInfo loginInfo,
         bool isPersistent)
      {
         var user = _userManager.Find(loginInfo.Login);
         if (user == null)
         {
            return SignInStatus.Failure;
         }

         if (_userManager.IsLockedOut(user.Id))
         {
            return SignInStatus.LockedOut;
         }

         return SignInOrTwoFactor(user, isPersistent);
      }


      private SignInStatus
         SignInOrTwoFactor(
         ApplicationUser user,
         bool isPersistent)
      {
         // ForceEmailVerifaction is an extended property defined in this
         // implemenation of ApplicationUserManager
         if (_userManager.ForceEmailVerification)
         {
            if (!user.EmailConfirmed)
            {
               return SignInStatus.NotVerified;
            }
         }

         if (_userManager.GetTwoFactorEnabled(user.Id) &&
             !Task.Run(
                async () =>
                   await
                      _authenticationManager.TwoFactorBrowserRememberedAsync(
                         user.Id)).Result)
         {
            var identity =
               new ClaimsIdentity(DefaultAuthenticationTypes.TwoFactorCookie);

            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id));

            _authenticationManager.SignIn(identity);

            return SignInStatus.RequiresTwoFactorAuthentication;
         }

         SignIn(user, isPersistent, false);
         return SignInStatus.Success;
      }


      public SignInStatus
         PasswordSignIn(
         string userName,
         string password,
         bool isPersistent,
         bool shouldLockout)
      {
         var user = _userManager.FindByName(userName);

         if (user == null)
         {
            return SignInStatus.Failure;
         }

         if (_userManager.IsLockedOut(user.Id))
         {
            return SignInStatus.LockedOut;
         }

         if (_userManager.CheckPassword(user, password))
         {
            return SignInOrTwoFactor(user, isPersistent);
         }

         if (shouldLockout)
         {
            // If lockout is requested, increment access failed count which 
            // might lock out the user
            _userManager.AccessFailed(user.Id);
            if (_userManager.IsLockedOut(user.Id))
            {
               return SignInStatus.LockedOut;
            }
         }

         return SignInStatus.Failure;
      }


      public void
         SignIn(
         ApplicationUser user,
         bool isPersistent)
      {
         _authenticationManager
            .SignOut(DefaultAuthenticationTypes.ExternalCookie);

         var identity = _userManager.CreateIdentity(
            user,
            DefaultAuthenticationTypes.ApplicationCookie
            );

         _authenticationManager.SignIn(
            new AuthenticationProperties {IsPersistent = isPersistent},
            identity
            );
      }

   }
}