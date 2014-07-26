using NavigationIdentity.Web.Controllers;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NavigationIdentity.Web.Views.Account.Controls
{
   public class BaseAccountUserControl : UserControl
   {

      public AccountController AccountController
      {
         get
         {
            var baseAccountPage = Page as BaseAccountPage;
            if (baseAccountPage == null)
            {
               throw new Exception("Page must derive from BaseAccountPage!");
            }
            return baseAccountPage.AccountController;
         }
      }


      protected void 
      GetAccountController(object sender, CallingDataMethodsEventArgs e)
      {
         e.DataMethodsObject = AccountController;
      }

   }
}