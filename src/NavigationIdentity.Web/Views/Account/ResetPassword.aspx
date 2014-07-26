<%@ Page Title="Reset Password" Language="C#" MasterPageFile="~/Views/Shared/Layout.Master" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="NavigationIdentity.Web.Views.Account.ResetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <asp:FormView runat="server" ItemType="NavigationIdentity.Web.Models.Account.ResetPasswordViewModel"
      DefaultMode="Insert" InsertMethod="ResetPassword"
      OnCallingDataMethods="GetAccountController" RenderOuterTable="false">
      <InsertItemTemplate>
         <div class="form-horizontal">
            <h2>Reset Password.</h2>

            <asp:ValidationSummary runat="server" CssClass="text-danger" />

            <div class="form-group">
               <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
               <div class="col-md-4">
                  <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" Text="<%# BindItem.Email %>" />
               </div>
            </div>
            <div class="form-group">
               <asp:Label runat="server" AssociatedControlID="NewPassword" CssClass="col-md-2 control-label">Password</asp:Label>
               <div class="col-md-4">
                  <asp:TextBox runat="server" ID="NewPassword" CssClass="form-control" TextMode="Password" Text="<%# BindItem.Password %>" />
               </div>
            </div>
            <div class="form-group">
               <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">Confirm Password</asp:Label>
               <div class="col-md-4">
                  <asp:TextBox runat="server" ID="ConfirmPassword" CssClass="form-control" TextMode="Password" Text="<%# BindItem.ConfirmPassword %>" />
               </div>
            </div>
            <div class="form-group">
               <div class="col-md-offset-2 col-md-10">
                  <asp:Button runat="server" Text="Reset Password" CommandName="Insert" CssClass="btn btn-primary" />
               </div>
            </div>
         </div>
      </InsertItemTemplate>
   </asp:FormView>
</asp:Content>
