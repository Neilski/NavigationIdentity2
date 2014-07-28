<%@ Page Title="Phone Number Verified" Language="C#" MasterPageFile="~/Views/Shared/Layout.Master" AutoEventWireup="true" CodeBehind="PhoneNumberVerified.aspx.cs" Inherits="NavigationIdentity.Web.Views.Account.PhoneNumberVerified" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <asp:FormView runat="server" RenderOuterTable="false"
      DefaultMode="ReadOnly"
      SelectMethod="GetPhoneNumberVerified" 
      OnCallingDataMethods="GetAccountController">
      <ItemTemplate>
         <h2>Phone Number Verified Successfully</h2>

         <p>
            Your phone number
            <strong><asp:Literal runat="server" ID="PhoneNumber" Text="<%# Item.PhoneNumber %>" Mode="Encode"></asp:Literal></strong>
            has been verified successfully.
         </p>
         
         <p>
            You can now use this number for receiving two-factor authentication
            codes.
         </p>
      </ItemTemplate>
   </asp:FormView>
</asp:Content>
