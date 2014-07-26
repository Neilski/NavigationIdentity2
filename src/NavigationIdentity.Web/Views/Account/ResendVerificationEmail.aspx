<%@ Page Title="Resend Verification Email" Language="C#" MasterPageFile="~/Views/Shared/Layout.Master" AutoEventWireup="true" CodeBehind="ResendVerificationEmail.aspx.cs" Inherits="NavigationIdentity.Web.Views.Account.ResendVerificationEmail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <asp:FormView runat="server" RenderOuterTable="false"
      DefaultMode="Insert" InsertMethod="ResendVerificationEmail" 
      OnCallingDataMethods="GetAccountController">
      <InsertItemTemplate>
         <h2><%: Title %></h2>
         <p>
            Before you can gain full access to this web site, you will need 
            to verify your registered email address.
         </p>
         <p>
            Click the 'Resend Email' button below to resend your verification
            link to your email adrress.
         </p>
         <p>
            <asp:Button runat="server" Text="Resend Email" CommandName="Insert" CssClass="btn btn-primary" />
         </p>
      </InsertItemTemplate>
   </asp:FormView>
</asp:Content>
