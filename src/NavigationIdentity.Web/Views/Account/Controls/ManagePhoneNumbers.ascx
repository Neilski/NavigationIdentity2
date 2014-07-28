<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManagePhoneNumbers.ascx.cs" Inherits="NavigationIdentity.Web.Views.Account.Controls.ManagePhoneNumbers" %>
<%@ Import Namespace="RestSharp.Extensions" %>

<asp:FormView runat="server" RenderOuterTable="false"
   DefaultMode="Edit"
   ItemType="NavigationIdentity.Web.Models.Account.ManagePhoneNumbersViewModel"
   SelectMethod="GetRegisteredPhoneNumber" 
   DeleteMethod="RemoveRegisteredPhoneNumber"
   OnCallingDataMethods="GetAccountController">
   <EditItemTemplate>
      <asp:Panel runat="server" Visible="<%# !Item.HasPhoneNumber %>">
         <asp:HyperLink runat="server" NavigateUrl="{NavigationLink AddPhoneNumber}">
            Add a Phone Number
         </asp:HyperLink>
      </asp:Panel>
      <asp:Panel runat="server" Visible="<%# Item.HasPhoneNumber %>">
         <span>Phone Number: <%#: Item.PhoneNumber %></span>
         <asp:HyperLink runat="server" NavigateUrl="{NavigationLink AddPhoneNumber}">[Change]</asp:HyperLink>
         &nbsp;|&nbsp;
         <asp:Button runat="server" Text="Remove" ToolTip="Remove phone number" CommandName="Delete" CssClass="btn btn-default btn-xs" />
      </asp:Panel>
   </EditItemTemplate>
</asp:FormView>
