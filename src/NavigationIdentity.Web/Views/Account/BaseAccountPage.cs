using NavigationIdentity.Web.Controllers;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NavigationIdentity.Web.Views.Account
{
   public class BaseAccountPage : Page
   {
      // Provide per instance/per request access to an AccountController
      private AccountController _accountController;
      public AccountController AccountController
      {
         get
         {
            if (_accountController == null)
            {
               _accountController = new AccountController();
            }
            return _accountController;
         }
      }

      // WebForm/WebControls access to the AccountController
      protected void 
      GetAccountController(object sender, CallingDataMethodsEventArgs e)
      {
         e.DataMethodsObject = AccountController;
      }

   }
}