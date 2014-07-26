<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManagePhoneNumbers.ascx.cs" Inherits="NavigationIdentity.Web.Views.Account.Controls.ManagePhoneNumbers" %>

<asp:FormView runat="server" RenderOuterTable="false"
   ItemType="NavigationIdentity.Web.Models.Account.ManagePhoneNumbersViewModel"
   DefaultMode="Edit"
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
         <span>Phone Number: <%# Item.PhoneNumber %></span>
         <asp:HyperLink runat="server" NavigateUrl="{NavigationLink AddPhoneNumber}">[Change]</asp:HyperLink>
         &nbsp;|&nbsp;
         <asp:LinkButton runat="server" ToolTip="Remove phone number" CommandName="Delete">[Remove]</asp:LinkButton>
      </asp:Panel>
   </EditItemTemplate>
</asp:FormView>
