<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManageTwoFactorBrowser.ascx.cs" Inherits="NavigationIdentity.Web.Views.Account.Controls.ManageTwoFactorBrowser" %>

<asp:FormView runat="server" ItemType="System.Boolean"
   DefaultMode="Edit" SelectMethod="GetRememberTwoFactorBrowser" 
   UpdateMethod="ToggleRememberTwoFactorBrowser"
   OnCallingDataMethods="GetAccountController" RenderOuterTable="false">
   <EditItemTemplate>
      <asp:Panel runat="server" Visible="<%# !Item %>">
         Remember Two Factor Browser: <strong>Disabled</strong>
         &nbsp;|&nbsp;
         <asp:LinkButton Text="[Enable]" runat="server" CommandName="Update" />
      </asp:Panel>
      <asp:Panel runat="server" Visible="<%# Item %>">
         Remember Two Factor Browser: <strong>Enabled</strong>
         &nbsp;|&nbsp;
         <asp:LinkButton Text="[Disable]" runat="server" CommandName="Update" />
      </asp:Panel>
   </EditItemTemplate>
</asp:FormView>
