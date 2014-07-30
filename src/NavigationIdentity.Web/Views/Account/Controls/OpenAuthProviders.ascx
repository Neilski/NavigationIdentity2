<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OpenAuthProviders.ascx.cs" Inherits="NavigationIdentity.Web.Views.Account.Controls.OpenAuthProviders" %>

<div id="socialLoginList">
   <asp:ListView runat="server" 
      ItemType="Microsoft.Owin.Security.AuthenticationDescription"
      SelectMethod="GetOpenAuthProviders"
      DataKeyNames="AuthenticationType"
      OnCallingDataMethods="GetAccountController">
      <EmptyDataTemplate>
         <p>
            There are no external authentication services configured.
            See <a href="http://go.microsoft.com/fwlink/?LinkId=313242">this article</a>
            for details on setting up this ASP.NET application to support 
            logging in via external services.
         </p>
      </EmptyDataTemplate>
      <LayoutTemplate>
         <ul class="list-unstyled">
         <li runat="server" ID="itemPlaceholder" />
         </ul>
      </LayoutTemplate>
      <ItemTemplate>
         <li class="margin-1">
            <asp:HiddenField ID="Provider" runat="server" Value="<%# Item.AuthenticationType %>" />
            <asp:FormView runat="server" RenderOuterTable="false"
               ItemType="Microsoft.Owin.Security.AuthenticationDescription"
               DefaultMode="Edit"
               DataKeyNames="AuthenticationType"
               SelectMethod="GetOpenAuthProvider"
               UpdateMethod="AssignOAuthProvider" 
               OnCallingDataMethods="GetAccountController">
               <EditItemTemplate>
                  <asp:Button runat="server" CommandName="Update" Text="<%# Item.AuthenticationType %>" 
                     CssClass="btn btn-default full-width" ToolTip='<%# String.Format("Log in using your {0} account", Item.Caption) %>' />
               </EditItemTemplate>
            </asp:FormView>
         </li>
      </ItemTemplate>
   </asp:ListView>
</div>
