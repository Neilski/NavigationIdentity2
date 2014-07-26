<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UnassignedOAuthProviders.ascx.cs" Inherits="NavigationIdentity.Web.Views.Account.Controls.UnassignedOAuthProviders" %>


<asp:ListView runat="server"
   ItemType="Microsoft.Owin.Security.AuthenticationDescription"
   SelectMethod="GetUnassignedOAuthProviders"
   UpdateMethod="AssignOAuthProvider"
   DataKeyNames="AuthenticationType"
   OnCallingDataMethods="GetAccountController">

   <LayoutTemplate>
      <ul class="list-unstyled">
         <li runat="server" id="itemPlaceholder"></li>
      </ul>
   </LayoutTemplate>
   <EmptyDataTemplate>
      <p>
         No external authentication providers are available.
      </p>
   </EmptyDataTemplate>
   <ItemTemplate>
      <li class="margin-05">
         <asp:Button runat="server" Text="<%# Item.AuthenticationType %>" CommandName="Update" CausesValidation="false"
            ToolTip='<%# "Add this " + Item.AuthenticationType + " login to your account" %>'
            CssClass="btn btn-default full-width" />
      </li>
   </ItemTemplate>
</asp:ListView>
