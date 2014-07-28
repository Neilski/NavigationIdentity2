<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManageTwoFactorBrowser.ascx.cs" Inherits="NavigationIdentity.Web.Views.Account.Controls.ManageTwoFactorBrowser" %>

<asp:FormView runat="server" RenderOuterTable="false"
   DefaultMode="Edit"
   ItemType="System.Boolean"
   SelectMethod="GetRememberTwoFactorBrowser" 
   UpdateMethod="ToggleRememberTwoFactorBrowser"
   OnCallingDataMethods="GetAccountController">
   <EditItemTemplate>
      <asp:Panel runat="server" Visible="<%# !Item %>">
         Remember Two Factor Browser: <strong>Disabled</strong>
         &nbsp;|&nbsp;
         <asp:Button runat="server" Text="Enable" CommandName="Update" CssClass="btn btn-default btn-xs" />
      </asp:Panel>
      <asp:Panel runat="server" Visible="<%# Item %>">
         Remember Two Factor Browser: <strong>Enabled</strong>
         &nbsp;|&nbsp;
         <asp:Button runat="server" Text="Disable" CommandName="Update" CssClass="btn btn-default btn-xs" />
      </asp:Panel>
   </EditItemTemplate>
</asp:FormView>
