using Microsoft.AspNet.Identity;
using System;
using System.Configuration;
using System.Threading.Tasks;
using Twilio;


namespace NavigationIdentity.Web.Services
{
   public class SmsService : IIdentityMessageService
   {

      public Task SendAsync(IdentityMessage message)
      {
         // Plug in your sms service here to send a text message...
         // Grab the Twilio account details from Web.config
         var twilioSid = ConfigurationManager.AppSettings["IdentityTwilioSid"];

         if (!String.IsNullOrWhiteSpace(twilioSid))
         {
            var twilioAuthToken =
               ConfigurationManager.AppSettings["IdentityTwilioAuthToken"];
            var twilioNumber =
               ConfigurationManager.AppSettings["IdentityTwilioNumber"];
            var twilio = new TwilioRestClient(twilioSid, twilioAuthToken);
            twilio.SendMessage(twilioNumber, message.Destination, message.Body);
         }

         return Task.FromResult(0);
      }


      public static string CreateSecurityCodeMessage()
      {
         return String.Format(
            "Your {0} security code is: {{0}}",
            ApplicationService.ApplicationName
            );
      }


      public static string CreateAuthenticatePhoneMessage(string code)
      {
         return String.Format(
            "Your {0} phone authentication security code is: {1}.",
            ApplicationService.ApplicationName, code
            );
      }

   }
}