<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AssignedOAuthProviders.ascx.cs" Inherits="NavigationIdentity.Web.Views.Account.Controls.AssignedOAuthProviders" %>


<asp:ListView runat="server"
   ItemType="Microsoft.Owin.Security.AuthenticationDescription"
   SelectMethod="GetAssignedOAuthProviders"
   DeleteMethod="UnassignOAuthProvider"
   DataKeyNames="AuthenticationType"
   OnCallingDataMethods="GetAccountController">

   <LayoutTemplate>
      <ul class="list-unstyled">
         <li runat="server" id="itemPlaceholder"></li>
      </ul>
   </LayoutTemplate>
   <EmptyDataTemplate>
      <p>
         No external authentication providers have been assigned to your 
         account.
      </p>
   </EmptyDataTemplate>
   <ItemTemplate>
      <li class="margin-05">
         <asp:Button runat="server" Text="<%#Item.AuthenticationType %>" CommandName="Delete" CausesValidation="false"
            ToolTip='<%# "Remove this " + Item.AuthenticationType + " login from your account" %>'
            CssClass="btn btn-default full-width" />
      </li>
   </ItemTemplate>
</asp:ListView>
