<%@ Page Title="Manage Account" Language="C#" MasterPageFile="~/Views/Shared/Layout.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="NavigationIdentity.Web.Views.Account.Manage" %>

<%@ Register Src="~/Views/Account/Controls/ManagePhoneNumbers.ascx" TagPrefix="uc1" TagName="ManagePhoneNumbers" %>
<%@ Register Src="~/Views/Account/Controls/ManageTwoFactorAuthentication.ascx" TagPrefix="uc1" TagName="ManageTwoFactorAuthentication" %>
<%@ Register Src="~/Views/Account/Controls/ManageTwoFactorBrowser.ascx" TagPrefix="uc1" TagName="ManageTwoFactorBrowser" %>
<%@ Register Src="~/Views/Account/Controls/AssignedOAuthProviders.ascx" TagPrefix="uc1" TagName="AssignedOAuthProviders" %>
<%@ Register Src="~/Views/Account/Controls/UnassignedOAuthProviders.ascx" TagPrefix="uc1" TagName="UnassignedOAuthProviders" %>

<asp:Content runat="server" ContentPlaceHolderID="JavaScript">
   <script type="text/javascript">
      $(function() {
         var $message = $("#status-message-panel");
         // Only hide trivial/information messages
         if (($message.length) && (!$message.hasClass("panel-danger"))) {
            setTimeout(function() {
               $message.slideUp(500);
            }, 5000);
         }
      });
   </script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <h2>Manage Account</h2>
   <div class="row">
      <div class="col-md-8">
         <h3>Local Account Details</h3>
         <hr />
         <asp:FormView runat="server" RenderOuterTable="false"
            ItemType="NavigationIdentity.Web.Models.Account.ManageViewModel"
            DefaultMode="ReadOnly" SelectMethod="Manage" 
            OnCallingDataMethods="GetAccountController">
            <ItemTemplate>
               
               <asp:Panel runat="server" Visible="<%# Item.HasMessage %>">
                  <div id="status-message-panel" class="panel panel-<%# ((Item.Error) ? "danger" : "success") %>">
                     <div class="panel-heading">
                        <%# Item.StatusMessage %>
                     </div>
                  </div>
               </asp:Panel>

               <p>Hello <%# Item.FirstName %>,</p>
               <p>
                  You are logged in as <strong><%# Item.UserName %></strong>
                  <asp:Label runat="server" CssClass="text-muted"
                     Visible="<%# !Item.UserNameEqualsEmail %>">
                     (email address: <%# Item.Email %>)
                  </asp:Label>
               </p>
               <asp:Panel runat="server" Visible="<%# !Item.IsEmailConfirmed %>">
                  <p>
                     Please 
                        <asp:HyperLink runat="server" NavigateUrl="{NavigationLink ResendVerificationEmail}">
                           <strong class="text-primary">Verify Your Account</strong>
                        </asp:HyperLink>
                     before continuing.
                  </p>
                  <p>
                     <em class="text-primary">Once your account verified you
                        will get full, unrestricted access to all 
                        features.</em>
                  </p>
               </asp:Panel>
               <asp:Panel runat="server" Visible="<%# Item.IsEmailConfirmed %>">
                  <p>What would you like to do?</p>
                  <ul>
                     <li>
                        <asp:HyperLink runat="server" NavigateUrl="{NavigationLink ChangePassword}">
                           Change Password
                        </asp:HyperLink>
                     </li>
                     <li>
                        <asp:HyperLink runat="server" NavigateUrl="{NavigationLink UpdatePersonalDetails}">
                           Update Personal Details
                        </asp:HyperLink>
                     </li>
                     <li>
                        <uc1:ManagePhoneNumbers runat="server" id="ManagePhoneNumbers" />
                     </li>
                     <li>
                        <uc1:ManageTwoFactorAuthentication runat="server" id="ManageTwoFactorAuthentication" />
                     </li>
                     <li>
                        <uc1:ManageTwoFactorBrowser runat="server" ID="ManageTwoFactorBrowser" />
                     </li>
                  </ul>
               </asp:Panel>
            </ItemTemplate>
         </asp:FormView>
      </div>
      <div class="col-md-4">
         <h3>Manage External Providers</h3>
         <hr />
         
         <div>
            <h4>Remove External Authentication Providers</h4>
            <uc1:AssignedOAuthProviders runat="server" id="AssignedOAuthProviders" />
         </div>

         <div class="margin-top-2">
            <h4>Add External Authentication Providers</h4>
            <uc1:UnassignedOAuthProviders runat="server" ID="UnassignedOAuthProviders" />
         </div>
      </div>
   </div>
</asp:Content>
