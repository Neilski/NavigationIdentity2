using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Navigation;
using NavigationIdentity.Models;
using NavigationIdentity.Web.Models.Account;
using NavigationIdentity.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI.WebControls;


namespace NavigationIdentity.Web.Controllers
{
   public partial class AccountController
   {
      #region Enumerations
      public enum ManageMessageId
      {

         AccountVerified,
         ChangePasswordSuccess,
         UserDetailsUpdateSuccess,
         SetPasswordSuccess,
         RemoveLoginSuccess,
         AddPhoneSuccess,
         RemovePhoneSuccess,
         TwoFactorAuthEnabledSuccess,
         TwoFactorAuthDisabledSuccess,
         RememberTwoFactorBrowserEnabledSuccess,
         RememberTwoFactorBrowserDisabledSuccess,
         Error

      }
      #endregion Enumerations



      #region Static/Readonly Properties
      private const string CodeKey = "Code";
      private const string UserIdKey = "UserId";
      private const string IsValidationReminderKey = "IsReminder";
      private const string ProviderNameKey = "ProviderName";
      private const string ReturnUrlKey = "ReturnUrl";
      private const string XsrfKey = "XsrfId";

      private readonly ApplicationUserManager _userManager;
      private readonly IAuthenticationManager _authenticationManager;
      private readonly HttpContextWrapper _context;
      private readonly HttpResponseWrapper _response;
      #endregion Static/Readonly Properties



      #region CTORs
      public AccountController(
         HttpContextWrapper httpContext,
         HttpResponseWrapper httpResponse)
      {
         _context = httpContext;
         _response = httpResponse;
         _authenticationManager = _context.GetOwinContext().Authentication;
         _userManager =
            _context.GetOwinContext().GetUserManager<ApplicationUserManager>();
      }


      public AccountController()
         : this(new HttpContextWrapper(HttpContext.Current),
            new HttpResponseWrapper(HttpContext.Current.Response))
      {
      }
      #endregion CTORs



      #region Manage
      public ManageViewModel
         Manage([NavigationData] ManageMessageId? message)
      {
         var user = GetCurrentUser();
         if (user == null)
         {
            RedirectToLogin(StateController.GetNavigationLink("Manager"));
            return null;
         }

         var model = new ManageViewModel
         {
            HasUserDetails = (user.UserDetails != null),
            IsEmailConfirmed = user.EmailConfirmed,
            UserName = user.UserName,
            Email = user.Email,
            UserNameEqualsEmail =
               (String.Compare(
                  user.UserName, user.Email,
                  StringComparison.InvariantCultureIgnoreCase) == 0),
            HasMessage = (message != null),
            StatusMessage = GetStatusMessage(message),
            Error = ((message != null) && (message >= ManageMessageId.Error))
         };

         if (user.UserDetails != null)
         {
            model.FirstName = user.UserDetails.FirstName;
            model.LastName = user.UserDetails.LastName;
         }

         StateContext.Bag.ReturnUrl =
            StateController.GetNavigationLink("Manage");

         return model;
      }


      public ManagePhoneNumbersViewModel
         GetRegisteredPhoneNumber()
      {
         var userId = _context.User.Identity.GetUserId();
         var phoneNumber = _userManager.GetPhoneNumber(userId);
         return new ManagePhoneNumbersViewModel
         {
            PhoneNumber = phoneNumber ?? "",
            HasPhoneNumber = !String.IsNullOrWhiteSpace(phoneNumber)
         };
      }


      public void
         RemoveRegisteredPhoneNumber()
      {
         var userId = _context.User.Identity.GetUserId();
         var result = _userManager.SetPhoneNumber(userId, null);
         if (!result.Succeeded)
         {
            RedirectToManager(ManageMessageId.Error);
            return;
         }

         var user = _userManager.FindById(userId);
         if (user != null)
         {
            SignIn(user, isPersistent: false);
            RedirectToManager(ManageMessageId.RemovePhoneSuccess);
         }
      }


      public bool
         GetTwoFactorAuthenticationEnabled()
      {
         var userId = _context.User.Identity.GetUserId();
         return _userManager.GetTwoFactorEnabled(userId);
      }


      public void
         ToggleTwoFactorAuthentication()
      {
         var userId = _context.User.Identity.GetUserId();
         var newState = !GetTwoFactorAuthenticationEnabled();
         var result = _userManager.SetTwoFactorEnabled(userId, newState);
         if (result.Succeeded)
         {
            RedirectToManager(
               (newState)
                  ? ManageMessageId.TwoFactorAuthEnabledSuccess
                  : ManageMessageId.TwoFactorAuthDisabledSuccess);
            return;
         }

         RedirectToManager(ManageMessageId.Error);
      }


      public bool
         GetRememberTwoFactorBrowser()
      {
         var userId = _context.User.Identity.GetUserId();
         return Task.Run(
            async () =>
               await _authenticationManager
                  .TwoFactorBrowserRememberedAsync(userId))
            .Result;
      }


      public void
         ToggleRememberTwoFactorBrowser()
      {
         var newState = !GetRememberTwoFactorBrowser();

         // Remember browser
         if (newState)
         {
            var userId = _context.User.Identity.GetUserId();
            var rememberBrowserIdentity = _authenticationManager
               .CreateTwoFactorRememberBrowserIdentity(userId);
            _authenticationManager.SignIn(
               new AuthenticationProperties {IsPersistent = true},
               rememberBrowserIdentity
               );
            RedirectToManager(
               ManageMessageId.RememberTwoFactorBrowserEnabledSuccess
               );
            return;
         }

         // Forget browser
         _authenticationManager.SignOut(
            DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie
            );
         RedirectToManager(
            ManageMessageId.RememberTwoFactorBrowserDisabledSuccess
            );
      }


      public void
         AssignOAuthProvider(AuthenticationDescription model)
      {
         var properties = new AuthenticationProperties
         {
            RedirectUri = StateController
               .GetNavigationLink(
                  "ExternalLoginHandler", new NavigationData
                  {
                     {ProviderNameKey, model.AuthenticationType},
                     {ReturnUrlKey, StateContext.Bag.ReturnUrl}
                  })
         };

         if (_context.User.Identity.IsAuthenticated)
         {
            properties.Dictionary[XsrfKey] = _context.User.Identity.GetUserId();
         }

         _authenticationManager.Challenge(properties, model.AuthenticationType);
         _response.StatusCode = 401;
         _response.End();
      }


      public void
         UnassignOAuthProvider(AuthenticationDescription model)
      {
         var userId = _context.User.Identity.GetUserId();
         var login = _userManager.GetLogins(userId)
            .FirstOrDefault(x => x.LoginProvider == model.AuthenticationType);
         var result = _userManager.RemoveLogin(userId, login);
         if (result.Succeeded)
         {
            var user = _userManager.FindById(userId);
            SignIn(user, isPersistent: false);
            RedirectToManager(ManageMessageId.RemoveLoginSuccess);
            return;
         }

         RedirectToManager(ManageMessageId.Error);
      }


      public PersonalDetailsViewModel
         GetPersonalDetails()
      {
         var userId = _context.User.Identity.GetUserId();
         if (userId == null)
         {
            RedirectToLogin(
               StateController.GetNavigationLink("UpdatePersonalDetails")
               );
            return null;
         }

         var user = _userManager.FindById(userId);
         var model = new PersonalDetailsViewModel();

         if (user.UserDetails == null) return model;

         model.Title = user.UserDetails.Title;
         model.FirstName = user.UserDetails.FirstName;
         model.LastName = user.UserDetails.LastName;
         model.Gender = user.UserDetails.Gender;
         model.DateOfBirth = user.UserDetails.DateOfBirth;

         return model;
      }


      public void
         UpdatePersonalDetails(
         PersonalDetailsViewModel model,
         ModelMethodContext context)
      {
         if (!context.ModelState.IsValid) return;

         var user = GetCurrentUser();
         user.UserDetails.Title = model.Title;
         user.UserDetails.FirstName = model.FirstName;
         user.UserDetails.LastName = model.LastName;
         user.UserDetails.Gender = model.Gender;
         user.UserDetails.DateOfBirth = model.DateOfBirth;

         var result = _userManager.Update(user);
         if (result.Succeeded)
         {
            RedirectToManager(ManageMessageId.UserDetailsUpdateSuccess);
            return;
         }

         AddErrors(result, context);
      }
      #endregion Manage



      #region Register
      public void
         Register(RegisterViewModel model, ModelMethodContext context)
      {
         if (!context.ModelState.IsValid) return;

         var newUser = CreateUserFromRegistration(model);

         IdentityResult result = _userManager.Create(newUser, model.Password);
         if (result.Succeeded)
         {
            RegisterNewUser(newUser);
            return;
         }

         AddErrors(result, context);
      }


      private void
         RegisterNewUser(ApplicationUser newUser)
      {
         SendEmailVerificationCode(newUser, reminder: false);
      }


      private void
         SendEmailVerificationCode(ApplicationUser user, bool reminder)
      {
         // For more information on how to enable account confirmation
         // and password reset please visit
         // http://go.microsoft.com/fwlink/?LinkID=320771
         string code = _userManager.GenerateEmailConfirmationToken(user.Id);

         string callbackUrl = GetEmailVerificationRedirectUrl(code, user.Id);

         _userManager.SendEmail(
            user.Id,
            "Confirm your account",
            EmailService.CreateRegistrationMessage(callbackUrl)
            );

         // DEMO-ONLY - ensure the Code and UserId parameters are omitted
         // in a production environment!
         StateController.Navigate(
            "RegistrationConfirmation",
            new NavigationData
            {
               {CodeKey, code},
               {UserIdKey, user.Id},
               {IsValidationReminderKey, reminder}
            });
      }


      public RegistrationConfirmationViewModel
         GetRegistrationConfirmation()
      {
         var model = new RegistrationConfirmationViewModel();
         var code = StateContext.Data[CodeKey] as string;
         var userId = StateContext.Data[UserIdKey] as string;
         model.IsRegistration =
            StateContext.Data[IsValidationReminderKey] as bool? ?? false;

         if ((code == null) || (userId == null)) return model;

         // DEMO-ONLY
         model.IsDemo = true;
         model.ConfirmationLink = GetEmailVerificationRedirectUrl(code, userId);

         return model;
      }


      // This method validates the new user's email address from the
      // generated security link
      public RegistrationEmailVerificationViewModel
         GetRegistrationEmailVerification()
      {
         string code = StateContext.Data[CodeKey] as string;
         string userId = StateContext.Data[UserIdKey] as string;

         if ((code != null) && (userId != null))
         {
            var result = _userManager.ConfirmEmail(userId, code);
            if (result.Succeeded)
            {
               // If the user is already logged in then return to the manager
               // with an appropriate message
               if (_context.User.Identity.IsAuthenticated)
               {
                  RedirectToManager(ManageMessageId.AccountVerified);
                  return null;
               }

               return new RegistrationEmailVerificationViewModel
               {
                  Success = true,
                  StatusMessage = "Thank you for verifying your account."
               };
            }
         }

         // Bad validation
         return new RegistrationEmailVerificationViewModel
         {
            Success = false,
            StatusMessage = "An error has occurred verifying your account."
         };
      }


      public void
         ResendVerificationEmail(ModelMethodContext context)
      {
         var user = GetCurrentUser();
         SendEmailVerificationCode(user, true);
      }
      #endregion Register



      #region Login/Logout
      public void
         Login(LoginViewModel model, ModelMethodContext context)
      {
         if (!context.ModelState.IsValid) return;

         // This doesn't count login failures towards lockout only two-factor
         // authentication. To enable password failures to trigger lockout,
         // change to shouldLockout: true - note here we are referencing the
         // ApplicationUserManager.UserLockoutEnabledByDefault property to set
         // the default action
         var result = PasswordSignIn(
            model.UserName, model.Password,
            model.RememberMe,
            shouldLockout: _userManager.UserLockoutEnabledByDefault);

         switch (result)
         {
            case SignInStatus.Success:
               RedirectToLocal();
               return;
            case SignInStatus.NotVerified:
               var user = _userManager.FindByName(model.UserName);
               SendEmailVerificationCode(user, reminder: true);
               return;
            case SignInStatus.LockedOut:
               StateController.Navigate("AccountLocked");
               return;
            case SignInStatus.RequiresTwoFactorAuthentication:
               StateController.Navigate(
                  "SendTwoFactorCode", new NavigationData
                  {
                     {ReturnUrlKey, StateContext.Data[ReturnUrlKey]}
                  });
               return;
            default: // case SignInStatus.Failure:
               context.ModelState.AddModelError("", "Invalid login attempt");
               return;
         }
      }


      public object Logout()
      {
         if ((StateContext.Bag.Logout != null) && (StateContext.Bag.Logout))
         {
            _authenticationManager.SignOut();
            StateController.Navigate("Home");
         }
         return new object();
      }
      #endregion Login/Logout



      #region Password Management
      public void
         RequestPasswordReset(
         RequestPasswordResetViewModel model,
         ModelMethodContext context)
      {
         if (!context.ModelState.IsValid) return;

         // Validate the user password
         var user = _userManager.FindByEmail(model.Email);
         if ((user == null) || (!_userManager.IsEmailConfirmed(user.Id)))
         {
            context.ModelState.AddModelError(
               "",
               "The user either does not exist or is not confirmed.");
            return;
         }

         // For more information on how to enable account confirmation and
         // password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
         // Send email with the code and the redirect to reset password page
         var code = _userManager.GeneratePasswordResetToken(user.Id);
         var callbackUrl = GetResetPasswordRedirectUrl(code);
         _userManager.SendEmail(
            user.Id,
            "Reset Password",
            EmailService.CreatePasswordResetMessage(callbackUrl)
            );

         // Modify this code to remove the code reference for production.
         // The code value should only be included for demonstration
         // purposes!
         StateController.Navigate(
            "RequestPasswordResetConfirmation",
            new NavigationData
            {
               {CodeKey, code}
            });
      }


      public RequestPasswordResetConfirmationViewModel
         GetRequestPasswordResetConfirmation()
      {
         // Modify this code to for production - the DemoLink value should only
         // be included for demonstration purposes!
         var model = new RequestPasswordResetConfirmationViewModel();
         var code = StateContext.Data[CodeKey] as string;

         if (code == null) return model;

         model.IsDemo = true;
         model.ResetLink = GetResetPasswordRedirectUrl(code);

         return model;
      }


      public void
         ResetPassword(ResetPasswordViewModel model, ModelMethodContext context)
      {
         if (!context.ModelState.IsValid) return;

         string code = StateContext.Data[CodeKey] as string;

         if (code == null)
         {
            context.ModelState.AddModelError("", "Invalid call to this page");
            return;
         }

         var user = _userManager.FindByEmail(model.Email);
         if (user == null)
         {
            context.ModelState.AddModelError("", "User not found!");
            return;
         }
         var result = _userManager.ResetPassword(user.Id, code, model.Password);
         if (result.Succeeded)
         {
            StateController.Navigate("ResetPasswordConfirmation");
         }
      }


      public void
         ChangePassword(
         ChangePasswordViewModel model,
         ModelMethodContext context)
      {
         if (!context.ModelState.IsValid) return;

         var userId = _context.User.Identity.GetUserId();
         var result = _userManager.ChangePassword(
            userId, model.CurrentPassword,
            model.NewPassword);
         if (result.Succeeded)
         {
            var user = _userManager.FindById(userId);
            SignIn(user, isPersistent: false);
            RedirectToManager(ManageMessageId.ChangePasswordSuccess);
            return;
         }

         AddErrors(result, context);
      }
      #endregion Password Management



      #region Two-Factor Authentication
      public void
         AddPhoneNumber(
         AddPhoneNumberViewModel model,
         ModelMethodContext context)
      {
         if (!context.ModelState.IsValid) return;

         var userId = _context.User.Identity.GetUserId();
         var code = _userManager.GenerateChangePhoneNumberToken(
            userId, model.PhoneNumber);

         if (_userManager.SmsService != null)
         {
            var message = new IdentityMessage
            {
               Destination = model.PhoneNumber,
               Body = SmsService.CreateAuthenticatePhoneMessage(code)
            };

            Task.Run(
               async () => { await _userManager.SmsService.SendAsync(message); });
         }

         // Modify this code to remove security code reference for
         // production - the code value should only be included for 
         // demonstration purposes!
         StateController.Navigate(
            "VerifyPhoneNumber", new NavigationData
            {
               {"PhoneNumber", model.PhoneNumber},
               {"DemoCode", code}
            });
      }


      public VerifyPhoneNumberViewModel
         GetVerifyPhoneNumber()
      {
         // Modify this code to for production - the DemoCode value should only
         // be included for demonstration purposes!
         return new VerifyPhoneNumberViewModel
         {
            IsDemo = true,
            DemoCode = StateContext.Data["DemoCode"] as string,
            PhoneNumber = StateContext.Data["PhoneNumber"] as string
         };
      }


      public void
         VerifyPhoneNumber(
         VerifyPhoneNumberViewModel model,
         ModelMethodContext context)
      {
         if (!context.ModelState.IsValid) return;

         var userId = _context.User.Identity.GetUserId();
         var result = _userManager.ChangePhoneNumber(
            userId, model.PhoneNumber, model.Code);

         if (result.Succeeded)
         {
            var user = _userManager.FindById(userId);

            if (user != null)
            {
               SignIn(user, false);
               RedirectToManager(ManageMessageId.AddPhoneSuccess);
            }
         }
         else
         {
            context.ModelState.AddModelError("", "Invalid verification code");
         }
      }


      public IEnumerable<string>
         GetValidTwoFactorProviders()
      {
         var userId = GetVerifiedUserId();
         return _userManager.GetValidTwoFactorProviders(userId);
      }


      public void
         SendTwoFactorCode(
         SendTwoFactorCodeViewModel model,
         ModelMethodContext context)
      {
         if (!context.ModelState.IsValid) return;

         var userId = GetVerifiedUserId();
         var user = _userManager.FindById(userId);
         if (user != null)
         {
            var code = _userManager.GenerateTwoFactorToken(
               user.Id,
               model.Provider);
            _userManager.NotifyTwoFactorToken(userId, model.Provider, code);

            StateController.Navigate(
               "VerifyTwoFactorCode", new NavigationData
               {
                  {ProviderNameKey, model.Provider},
                  {CodeKey, code},
                  {ReturnUrlKey, StateContext.Bag.ReturnUrl}
               });
         }
         else
         {
            context.ModelState.AddModelError(
               "",
               "Unable to identify current user!");
         }
      }


      public VerifyTwoFactorCodeViewModel
         GetVerifyTwoFactorCode()
      {
         var model = new VerifyTwoFactorCodeViewModel
         {
            Provider = StateContext.Data[ProviderNameKey] as string
         };

         var code = StateContext.Data[CodeKey] as string;
         if (code != null)
         {
            model.IsDemo = true;
            model.DemoCode = code;
         }

         return model;
      }


      public void
         VerifyTwoFactorCode(
         VerifyTwoFactorCodeViewModel model,
         ModelMethodContext context)
      {
         if (!context.ModelState.IsValid) return;

         var result = TwoFactorSignIn(
            model.Provider, model.Code,
            isPersistent: false, rememberBrowser: model.RememberBrowser);

         switch (result)
         {
            case SignInStatus.Success:
               RedirectToLocal();
               return;
            case SignInStatus.LockedOut:
               StateController.Navigate("AccountLocked");
               return;
            default:
               context.ModelState.AddModelError("Code", "Invalid Code");
               break;
         }
      }
      #endregion Two-Factor Authentication



      #region OAuth Providers
      public IEnumerable<AuthenticationDescription>
         GetOpenAuthProviders()
      {
         return _context.GetOwinContext().Authentication
            .GetExternalAuthenticationTypes();
      }


      public IEnumerable<AuthenticationDescription>
         GetAssignedOAuthProviders()
      {
         var userId = _context.User.Identity.GetUserId();
         var logins = _userManager.GetLogins(userId);
         var providers = GetOpenAuthProviders();

         return providers.Where(
            p => logins
               .Select(a => a.LoginProvider)
               .Contains(p.AuthenticationType));
      }


      public IEnumerable<AuthenticationDescription>
         GetUnassignedOAuthProviders()
      {
         var assigned = GetAssignedOAuthProviders();
         var providers = GetOpenAuthProviders();

         return providers.Where(
            p => !assigned
               .Select(a => a.AuthenticationType)
               .Contains(p.AuthenticationType));
      }


      public AuthenticationDescription
         GetOpenAuthProvider([Control] string provider)
      {
         return _context.GetOwinContext().Authentication
            .GetExternalAuthenticationTypes()
            .First(e => e.AuthenticationType == provider);
      }


      public ExternalLoginHandlerViewModel
         GetExternalLoginHandler(ModelMethodContext context)
      {
         var model = new ExternalLoginHandlerViewModel
         {
            ProviderName = StateContext.Data[ProviderNameKey] as string
         };

         // Check that a Provider is specified
         if (String.IsNullOrWhiteSpace(model.ProviderName))
         {
            ExternalLoginFailRedirect();
            return null;
         }

         var loginInfo = _authenticationManager.GetExternalLoginInfo();

         if (loginInfo == null)
         {
            ExternalLoginFailRedirect();
            return null;
         }

         var signInStatus = ExternalSignIn(loginInfo, false);

         switch (signInStatus)
         {
            case SignInStatus.Success:
               RedirectToLocal();
               return null;
            case SignInStatus.NotVerified:
               var user = _userManager.Find(loginInfo.Login);
               SendEmailVerificationCode(user, reminder: true);
               return null;
            case SignInStatus.LockedOut:
               StateController.Navigate("AccountLocked");
               return null;
            case SignInStatus.RequiresTwoFactorAuthentication:
               StateController.Navigate(
                  "SendTwoFactorCode", new NavigationData
                  {
                     {ReturnUrlKey, StateContext.Bag.ReturnUrlKey}
                  });
               return null;
         }

         if (_context.User.Identity.IsAuthenticated)
         {
            // Apply Xsrf check when linking
            var userId = _context.User.Identity.GetUserId();
            var verifiedloginInfo = _authenticationManager
               .GetExternalLoginInfo(XsrfKey, userId);

            if (verifiedloginInfo == null)
            {
               ExternalLoginFailRedirect();
               return null;
            }

            var result = _userManager.AddLogin(userId, verifiedloginInfo.Login);
            if (result.Succeeded)
            {
               RedirectToLocal();
               return null;
            }

            AddErrors(result, context);
         }
         else
         {
            // It's a new account, so get additional local details
            model.UserName = loginInfo.DefaultUserName;
            model.Email = loginInfo.Email;
         }

         return model;
      }


      public void
         ExternalLoginHandler(
         ExternalLoginHandlerViewModel model,
         ModelMethodContext context)
      {
         if (!context.ModelState.IsValid) return;

         var newUser = CreateUserFromRegistration(model);

         var result = _userManager.Create(newUser);
         if (result.Succeeded)
         {
            var loginInfo = _context.GetOwinContext().Authentication
               .GetExternalLoginInfo();

            if (loginInfo == null)
            {
               ExternalLoginFailRedirect();
               return;
            }

            result = _userManager.AddLogin(newUser.Id, loginInfo.Login);
            if (result.Succeeded)
            {
               // Microsoft's default approach does not validate the user's
               // email address, deferring the authentication to the 
               // third-party provider.
               //
               // SignIn(user, isPersistent: false);
               // RedirectToLocal();

               RegisterNewUser(newUser);
               return;
            }
         }

         AddErrors(result, context);
      }
      #endregion OAuth Providers
   }
}