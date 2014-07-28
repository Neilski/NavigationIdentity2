<%@ Page Title="Change Password" Language="C#" MasterPageFile="~/Views/Shared/Layout.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="NavigationIdentity.Web.Views.Account.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <asp:FormView runat="server" RenderOuterTable="false"
      ItemType="NavigationIdentity.Web.Models.Account.ChangePasswordViewModel"
      DefaultMode="Insert"
      InsertMethod="ChangePassword" 
      OnCallingDataMethods="GetAccountController">
      <InsertItemTemplate>
         <div class="form-horizontal">
            <h2>Change Password.</h2>

            <asp:ValidationSummary runat="server" CssClass="text-danger" />

            <div class="form-group">
               <asp:Label runat="server" AssociatedControlID="CurrentPassword" CssClass="col-md-2 control-label">Current Password</asp:Label>
               <div class="col-md-4">
                  <asp:TextBox runat="server" ID="CurrentPassword" CssClass="form-control" TextMode="Password" Text="<%# BindItem.CurrentPassword %>" />
               </div>
            </div>
            <div class="form-group">
               <asp:Label runat="server" AssociatedControlID="NewPassword" CssClass="col-md-2 control-label">New Password</asp:Label>
               <div class="col-md-4">
                  <asp:TextBox runat="server" ID="NewPassword" CssClass="form-control" TextMode="Password" Text="<%# BindItem.NewPassword %>" />
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
                  <asp:Button runat="server" Text="Submit" CommandName="Insert" CssClass="btn btn-primary" />
               </div>
            </div>
         </div>
      </InsertItemTemplate>
   </asp:FormView>
</asp:Content>
