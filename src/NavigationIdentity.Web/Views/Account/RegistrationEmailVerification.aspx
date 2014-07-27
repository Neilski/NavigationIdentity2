<%@ Page Title="Registration Email Verified" Language="C#" AutoEventWireup="true" CodeBehind="RegistrationEmailVerification.aspx.cs" Inherits="NavigationIdentity.Web.Views.Account.RegistrationEmailVerification" MasterPageFile="~/Views/Shared/Layout.Master" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
   <asp:FormView runat="server" RenderOuterTable="false"
      ItemType="NavigationIdentity.Web.Models.Account.RegistrationEmailVerificationViewModel"
      DefaultMode="ReadOnly" SelectMethod="GetRegistrationEmailVerification" 
      OnCallingDataMethods="GetAccountController">
      <ItemTemplate>
         <h2>Email Verified</h2>

         <asp:Panel runat="server" ID="pnlSuccess" Visible="<%# Item.Success %>">
            <p>
               Thank you.  Your account has been verified and you will now be able to
               <asp:HyperLink runat="server" NavigateUrl="{NavigationLink Manage}">login</asp:HyperLink>
               to your new account.
            </p>
         </asp:Panel>
         
         <asp:Panel runat="server" ID="pnlFailure" Visible="<%# Item.Failure %>">
            <p>
               We are sorry, but we have not been able to verify your account
               email from this security link.
            </p>
            <p>
               Please try clicking on the link in your email again or
               <asp:HyperLink runat="server" NavigateUrl="{NavigationLink Contact}">contacting</asp:HyperLink>
               the web site administrator.
            </p>
         </asp:Panel>
      </ItemTemplate>
   </asp:FormView>
</asp:Content>
