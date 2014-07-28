using System.Web.UI;
using System.Web.UI.WebControls;
using NavigationIdentity.Web.Controllers;


namespace NavigationIdentity.Web.Views.Account
{
   public partial class RegistrationEmailVerification 
      : Page
   {
      protected void
      GetAccountController(object sender, CallingDataMethodsEventArgs e)
      {
         e.DataMethodsObject = new AccountController();
      }
   }
}