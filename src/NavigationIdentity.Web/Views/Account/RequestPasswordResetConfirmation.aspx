<%@ Page Title="Request Password Reset Confirmation" Language="C#" MasterPageFile="~/Views/Shared/Layout.Master" AutoEventWireup="true" CodeBehind="RequestPasswordResetConfirmation.aspx.cs" Inherits="NavigationIdentity.Web.Views.Account.RequestPasswordResetConfirmation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <asp:FormView runat="server" ItemType="NavigationIdentity.Web.Models.Account.RequestPasswordResetConfirmationViewModel"
      DefaultMode="ReadOnly" SelectMethod="GetRequestPasswordResetConfirmation" 
      OnCallingDataMethods="GetAccountController" RenderOuterTable="false">
      <ItemTemplate>
         <h2>Reset Password Confirmation</h2>

         <p>
            An email has been sent to your registered email address containing
            a reset link.  Once you have clicked on this link you will be able
            to reset your password.
         </p>
         
         <!-- Only display for demo purposes -->
         <asp:Panel runat="server" ID="pnlDemoOnly" Visible="<%# Item.IsDemo %>">
            <hr />
            <h3>Demo Purposes Only!</h3>
            <p>
               The following link is the same as the link sent via email.
               Click on this link to validate your account.
            </p>
            <p>
               <a class="btn btn-primary" href="<%# Item.ResetLink %>">Reset Password</a>
            </p>
         </asp:Panel>
      </ItemTemplate>
   </asp:FormView>
</asp:Content>
