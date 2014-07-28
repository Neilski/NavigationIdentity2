<%@ Page Title="Send Two-Factor Code" Language="C#" MasterPageFile="~/Views/Shared/Layout.Master" AutoEventWireup="true" CodeBehind="SendTwoFactorCode.aspx.cs" Inherits="NavigationIdentity.Web.Views.Account.SendTwoFactorCode" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <asp:FormView runat="server" RenderOuterTable="false"
      ItemType="NavigationIdentity.Web.Models.Account.SendTwoFactorCodeViewModel"
      DefaultMode="Insert"
      InsertMethod="SendTwoFactorCode"
      OnCallingDataMethods="GetAccountController">
      <InsertItemTemplate>
         <div class="form-horizontal">
            <h2>Send Two-Factor Authentication Code.</h2>

            <p>
               Please select the provider you wish to validate.
            </p>

            <asp:ValidationSummary runat="server" CssClass="text-danger" />

            <div class="form-group">
               <asp:Label runat="server" AssociatedControlID="Providers" CssClass="col-md-2 control-label">Two-Factor Providers</asp:Label>
               <div class="col-md-4">
                  <asp:DropDownList runat="server" ID="Providers" 
                     ItemType="System.String" 
                     OnCallingDataMethods="GetAccountController" 
                     SelectMethod="GetValidTwoFactorProviders" 
                     SelectedValue="<%# BindItem.Provider %>" 
                     CssClass="form-control" />
               </div>
            </div>
            <div class="form-group">
               <div class="col-md-offset-2 col-md-10">
                  <asp:Button runat="server" Text="Submit" CommandName="Insert" CssClass="btn btn-primary" />
               </div>
            </div>
         </div>
      </InsertItemTemplate>
   </asp:FormView>
</asp:Content>
