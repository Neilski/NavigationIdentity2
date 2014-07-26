<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManageTwoFactorAuthentication.ascx.cs" Inherits="NavigationIdentity.Web.Views.Account.Controls.ManageTwoFactorAuthentication" %>

<asp:FormView runat="server" ItemType="System.Boolean"
   DefaultMode="Edit" SelectMethod="GetTwoFactorAuthenticationEnabled" 
   UpdateMethod="ToggleTwoFactorAuthentication"
   OnCallingDataMethods="GetAccountController" RenderOuterTable="false">
   <EditItemTemplate>
      <asp:Panel runat="server" Visible="<%# !Item %>">
         Two Factor Authentication: <strong>Disabled</strong>
         &nbsp;|&nbsp;
         <asp:LinkButton Text="[Enable]" runat="server" CommandName="Update" />
      </asp:Panel>
      <asp:Panel runat="server" Visible="<%# Item %>">
         Two Factor Authentication: <strong>Enabled</strong>
         &nbsp;|&nbsp;
         <asp:LinkButton Text="[Disable]" runat="server" CommandName="Update" />
      </asp:Panel>
   </EditItemTemplate>
</asp:FormView>
