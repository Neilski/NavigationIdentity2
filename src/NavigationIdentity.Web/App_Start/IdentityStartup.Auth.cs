using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using NavigationIdentity.Dal;
using NavigationIdentity.Models;
using NavigationIdentity.Models.Extensions;
using Owin;
using System;
using System.Configuration;

namespace NavigationIdentity.Web
{
   /// <summary>
   /// This class configures the default authentication related parameters.
   /// Modify this code as required to:
   /// 
   /// - Set login attempt window
   /// - Enable two-factor authentication (2FA)
   /// - Configure third-party login providers
   /// 
   /// For more information on configuring authentication, please visit
   /// http://go.microsoft.com/fwlink/?LinkId=301883
   /// </summary>
   public partial class IdentityStartup
   {
      public void ConfigureAuth(IAppBuilder app)
      {
         // Configure the db context and user manager to use a single instance
         // per request
         app.CreatePerOwinContext(ApplicationDbContext.Create);

         app.CreatePerOwinContext<ApplicationUserManager>(
            ApplicationUserManagerFactory.Create);


         // Enable the application to use a cookie to store information for the
         // signed in user and to use a cookie to temporarily store information
         // about a user logging in with a third party login provider.
         // Configure the sign in cookie
         app.UseCookieAuthentication(
            new CookieAuthenticationOptions
            {
               AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
               LoginPath = new PathString("/Account/Login"),
               Provider = new CookieAuthenticationProvider
               {
                  OnValidateIdentity =
                     SecurityStampValidator
                        .OnValidateIdentity
                        <ApplicationUserManager, ApplicationUser>(
                           validateInterval: TimeSpan.FromMinutes(20),
                           regenerateIdentity:
                              (manager, user) =>
                                 user.GenerateUserIdentityAsync(manager))
               }
            });

         // Use a cookie to temporarily store information about a user logging
         // in with a third party login provider
         app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

         // Enables the application to temporarily store user information when
         // they are verifying the second factor in the two-factor 
         // authentication process.
         app.UseTwoFactorSignInCookie(
            DefaultAuthenticationTypes.TwoFactorCookie,
            TimeSpan.FromMinutes(5)
         );

         // Enables the application to remember the second login verification
         // factor such as phone or email.  Once you check this option, your 
         // second step of verification during the login process will be
         // remembered on the device where you logged in from. This is similar
         // to the RememberMe option when you log in.
         app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

         // Modify Web.config settings to enable logging in with third-party
         // login providers.  See http://go.microsoft.com/fwlink/?LinkId=252803
         // for details on setting up this ASP.NET application to support 
         // logging in via external services.

         string microsoftClientId  = ConfigurationManager.AppSettings["AuthMicrosoftClientId"];
         string twitterConsumerKey = ConfigurationManager.AppSettings["AuthTwitterApiKey"];
         string facebookAppId      = ConfigurationManager.AppSettings["AuthFacebookAppId"];
         string googleClientId     = ConfigurationManager.AppSettings["AuthGoogleClientId"];

         // https://account.live.com/developers/applications/
         // http://www.benday.com/2014/02/25/walkthrough-asp-net-mvc-identity-with-microsoft-account-authentication/
         // Configure RedirectUrl as http://www.mysampleapp.com/signin-microsoft
         if (!String.IsNullOrWhiteSpace(microsoftClientId))
         {
            string clientSecret = ConfigurationManager.AppSettings["AuthMicrosoftClientSecret"];
            app.UseMicrosoftAccountAuthentication(clientId: microsoftClientId, clientSecret: clientSecret);
         }

         // https://dev.twitter.com/
         if (!String.IsNullOrWhiteSpace(twitterConsumerKey))
         {
            string consumerSecret = ConfigurationManager.AppSettings["AuthTwitterApiSecret"];
            app.UseTwitterAuthentication(consumerKey: twitterConsumerKey, consumerSecret: consumerSecret);
         }

         // https://developers.facebook.com/apps
         if (!String.IsNullOrWhiteSpace(facebookAppId))
         {
            string appSecret = ConfigurationManager.AppSettings["AuthFacebookAppSecret"];
            app.UseFacebookAuthentication(appId: facebookAppId, appSecret: appSecret);
         }

         // https://console.developers.google.com/
         // http://www.asp.net/mvc/tutorials/mvc-5/create-an-aspnet-mvc-5-app-with-facebook-and-google-oauth2-and-openid-sign-on
         // Configure RedirectUrl as http://www.mysampleapp.com/signin-google
         if (!String.IsNullOrWhiteSpace(googleClientId))
         {
            string clientSecret = ConfigurationManager.AppSettings["AuthGoogleClientSecret"];
            app.UseGoogleAuthentication(
               clientId: googleClientId,
               clientSecret: clientSecret
            );
         }
      }
   }
}
