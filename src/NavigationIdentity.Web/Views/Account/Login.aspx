<%@ Page Title="Login" Language="C#" MasterPageFile="~/Views/Shared/Layout.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="NavigationIdentity.Web.Views.Account.Login" %>

<%@ Register Src="~/Views/Account/Controls/OpenAuthProviders.ascx" TagPrefix="uc1" TagName="OpenAuthProviders" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <asp:FormView runat="server" RenderOuterTable="false"
      ItemType="NavigationIdentity.Web.Models.Account.LoginViewModel"
      DefaultMode="Insert"
      InsertMethod="Login" 
      OnCallingDataMethods="GetAccountController">
      <InsertItemTemplate>
         <h2>Log in.</h2>
         <div class="row">
            <div class="col-md-8">
               <div id="loginForm">
                  <div class="form-horizontal">
                     <h4>Use a local account to log in.</h4>
                     <hr />
                     <asp:ValidationSummary runat="server" CssClass="text-danger" />

                     <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="UserName" CssClass="col-md-2 control-label">User name</asp:Label>
                        <div class="col-md-6">
                           <asp:TextBox runat="server" ID="UserName" CssClass="form-control" Text="<%# BindItem.UserName %>" />
                        </div>
                     </div>
                     <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password</asp:Label>
                        <div class="col-md-6">
                           <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" Text="<%# BindItem.Password %>" />
                        </div>
                     </div>
                     <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                           <div class="checkbox">
                              <asp:CheckBox runat="server" ID="RememberMe" Checked="<%# BindItem.RememberMe %>" />
                              <asp:Label runat="server" AssociatedControlID="RememberMe">Remember me?</asp:Label>
                           </div>
                        </div>
                     </div>
                     <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                           <asp:Button runat="server" Text="Log in" CommandName="Insert" CssClass="btn btn-primary" />
                        </div>
                     </div>
                  </div>
                  <p>
                     <asp:HyperLink runat="server" NavigateUrl="{NavigationLink Register, ReturnUrl}">
                        Register if you don't have a local account.
                     </asp:HyperLink>
                     
                  </p>
                  <p>
                     <asp:HyperLink runat="server" NavigateUrl="{NavigationLink RequestPasswordReset, ReturnUrl}">
                        Forgot your password?
                     </asp:HyperLink>
                  </p>
               </div>
            </div>
            <div class="col-md-4">
               <h4>Use another service to log in.</h4>
               <hr />
               <uc1:OpenAuthProviders runat="server" ID="OpenAuthProviders" />
            </div>
         </div>
      </InsertItemTemplate>
   </asp:FormView>
</asp:Content>
