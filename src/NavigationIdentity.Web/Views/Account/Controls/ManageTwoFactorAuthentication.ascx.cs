using System.Web.UI;
using System.Web.UI.WebControls;
using NavigationIdentity.Web.Controllers;


namespace NavigationIdentity.Web.Views.Account.Controls
{
   public partial class ManageTwoFactorAuthentication
      : UserControl
   {
      protected void
      GetAccountController(object sender, CallingDataMethodsEventArgs e)
      {
         e.DataMethodsObject = new AccountController();
      }
   }
}