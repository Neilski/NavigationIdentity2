using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using NavigationIdentity.Dal;
using NavigationIdentity.Models;
using NavigationIdentity.Web.Services;
using System;

namespace NavigationIdentity.Web
{
   /// <summary>
   /// This factory class is responsible for creating and configuring the
   /// application wide ApplicationUserManager object.  Modify this class to
   /// adjust:
   /// 
   /// - username requirements
   /// - password strengths
   /// - email/SMS token providers
   /// - account locking requirements
   /// </summary>
   public static class ApplicationUserManagerFactory
   {
      public static ApplicationUserManager Create(
         IdentityFactoryOptions<ApplicationUserManager> options,
         IOwinContext context)
      {
         var manager = new ApplicationUserManager(
            new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>())
         );

         // Configure validation for usernames
         manager.UserValidator = new UserValidator<ApplicationUser>(manager)
         {
            AllowOnlyAlphanumericUserNames = true,
            RequireUniqueEmail = true
         };

         // Configure validation for passwords
         manager.PasswordValidator = new PasswordValidator
         {
            RequiredLength = 8,
            RequireNonLetterOrDigit = false,
            RequireDigit = true,
            RequireLowercase = true,
            RequireUppercase = true
         };

         // Configure user lockout defaults
         manager.ForceEmailVerification = false;
         manager.UserLockoutEnabledByDefault = true;
         manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(10);
         manager.MaxFailedAccessAttemptsBeforeLockout = 5;

         // Register two factor authentication providers. This application 
         // uses Phone and Emails as a step of receiving a code for 
         // verifying the user.
         //
         // For more information on using two-factor authentication please 
         // see http://go.microsoft.com/fwlink/?LinkID=391935
         // You can write your own provider and plug in here.

         manager.EmailService = new EmailService();
         manager.SmsService = new SmsService();

         manager.RegisterTwoFactorProvider(
            "Phone Code",
            new PhoneNumberTokenProvider<ApplicationUser>
            {
               MessageFormat = SmsService.CreateSecurityCodeMessage()
            }
         );

         manager.RegisterTwoFactorProvider(
            "Email Code",
            new EmailTokenProvider<ApplicationUser>
            {
               Subject = ApplicationService.ApplicationName + " - Security Code",
               BodyFormat = EmailService.CreateSecurityCodeMessage()
            }
         );

         var dataProtectionProvider = options.DataProtectionProvider;
         if (dataProtectionProvider != null)
         {
            manager.UserTokenProvider = 
               new DataProtectorTokenProvider<ApplicationUser>(
                  dataProtectionProvider.Create("ASP.NET Identity")
               );
         }

         return manager;
      }
   }
}