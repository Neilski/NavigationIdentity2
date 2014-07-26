<%@ Page Title="Password Reset Successful" Language="C#" MasterPageFile="~/Views/Shared/Layout.Master" AutoEventWireup="true" CodeBehind="ResetPasswordConfirmation.aspx.cs" Inherits="NavigationIdentity.Web.Views.Account.ResetPasswordConfirmation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <h2>Password Reset Successful</h2>

   <p>
      Your password has been reset as requested.  You will need to use your
      new password the next time you 
      <asp:HyperLink runat="server" 
         NavigateUrl="{NavigationLink Login}">login</asp:HyperLink>.
   </p>
</asp:Content>
