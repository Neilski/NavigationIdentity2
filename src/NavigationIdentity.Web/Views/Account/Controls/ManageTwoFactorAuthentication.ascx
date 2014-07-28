<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManageTwoFactorAuthentication.ascx.cs" Inherits="NavigationIdentity.Web.Views.Account.Controls.ManageTwoFactorAuthentication" %>

<asp:FormView runat="server" RenderOuterTable="false"
   DefaultMode="Edit"
   ItemType="System.Boolean"
   SelectMethod="GetTwoFactorAuthenticationEnabled" 
   UpdateMethod="ToggleTwoFactorAuthentication"
   OnCallingDataMethods="GetAccountController">
   <EditItemTemplate>
      <asp:Panel runat="server" Visible="<%# !Item %>">
         Two Factor Authentication: <strong>Disabled</strong>
         &nbsp;|&nbsp;
         <asp:Button runat="server" Text="Enable" CommandName="Update" CssClass="btn btn-default btn-xs" />
      </asp:Panel>
      <asp:Panel runat="server" Visible="<%# Item %>">
         Two Factor Authentication: <strong>Enabled</strong>
         &nbsp;|&nbsp;
         <asp:Button runat="server" Text="Disable" CommandName="Update" CssClass="btn btn-default btn-xs" />
      </asp:Panel>
   </EditItemTemplate>
</asp:FormView>
