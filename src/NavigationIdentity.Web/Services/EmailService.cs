using Microsoft.AspNet.Identity;
using System;
using System.Configuration;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace NavigationIdentity.Web.Services
{
   public class EmailService : IIdentityMessageService
   {
      public Task SendAsync(IdentityMessage message)
      {
         var fromEmailAddress = ConfigurationManager.AppSettings["IdentityFromEmailAddress"];

         var text = message.Body;
         var html = message.Body;

         // Do whatever you want to the message
         using (var msg = new MailMessage())
         {
            msg.From = new MailAddress(fromEmailAddress);
            msg.To.Add(new MailAddress(message.Destination));
            msg.Subject = message.Subject;

            msg.AlternateViews.Add(
               AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain)
            );

            msg.AlternateViews.Add(
               AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html)
            );


            // var smtpClient = new SmtpClient("smtp.whatever.net", Convert.ToInt32(587));
            // var credentials = new System.Net.NetworkCredential(Keys.EmailUser, Keys.EMailKey);
            // smtpClient.Credentials = credentials;

            using (var smtpClient = new SmtpClient())
            {
               smtpClient.Send(msg);
            }
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

      public static string CreateRegistrationMessage(string callbackUrl)
      {
         var msg = new StringBuilder();
         msg.AppendFormat(
            "Thank you for registering on the {0} web site.\n",
            ApplicationService.ApplicationName
         );
         msg.Append("Please confirm your account credentials by clicking ");
         msg.AppendFormat("<a href=\"{0}\">here</a>.", callbackUrl);
         return msg.ToString();
      }

      public static string CreatePasswordResetMessage(string callbackUrl)
      {
         return String.Format(
            "Please reset your {0} password by clicking <a href=\"{1}\">here</a>.",
            ApplicationService.ApplicationName, callbackUrl
         );
      }
   }
}