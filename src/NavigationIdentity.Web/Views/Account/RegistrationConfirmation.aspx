<%@ Page Title="Registration Confirmation" Language="C#" AutoEventWireup="true" CodeBehind="RegistrationConfirmation.aspx.cs" Inherits="NavigationIdentity.Web.Views.Account.RegistrationConfirmation" MasterPageFile="~/Views/Shared/Layout.Master" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
   <asp:FormView runat="server" RenderOuterTable="false"
      ItemType="NavigationIdentity.Web.Models.Account.RegistrationConfirmationViewModel"
      DefaultMode="ReadOnly"
      SelectMethod="GetRegistrationConfirmation"
      OnCallingDataMethods="GetAccountController">
      <ItemTemplate>
         <h2>Account Confirmation</h2>
         
         <asp:Panel runat="server" Visible="<%# !Item.IsRegistration %>">
            <p>
               Thank you for registering.
            </p>
         </asp:Panel>
         <asp:Panel runat="server" Visible="<%# Item.IsRegistration %>">
            <p>
               Please validate your account details before continuing.
            </p>
         </asp:Panel>
         <p>
            An email has been sent to your registered email address containing
            a validation link.  Once you have clicked on the link in the email
            you will be able to login.
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
               <a class="btn btn-primary" href="<%# Item.ConfirmationLink %>">Validate Account</a>
            </p>
         </asp:Panel>
      </ItemTemplate>
   </asp:FormView>
</asp:Content>
