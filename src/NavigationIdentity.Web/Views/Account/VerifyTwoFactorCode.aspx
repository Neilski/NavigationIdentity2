<%@ Page Title="Verify Two-Factor Code" Language="C#" MasterPageFile="~/Views/Shared/Layout.Master" AutoEventWireup="true" CodeBehind="VerifyTwoFactorCode.aspx.cs" Inherits="NavigationIdentity.Web.Views.Account.VerifyTwoFactorCode" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <asp:FormView runat="server" RenderOuterTable="false"
      ItemType="NavigationIdentity.Web.Models.Account.VerifyTwoFactorCodeViewModel"
      DefaultMode="Edit"
      DataKeyNames="Provider"
      SelectMethod="GetVerifyTwoFactorCode"
      UpdateMethod="VerifyTwoFactorCode"
      OnCallingDataMethods="GetAccountController">
      <EditItemTemplate>
         <div class="form-horizontal">
            <h2>Verify Two-Factor Code</h2>

            <p>
               A verifaction code has been sent to your 
               <strong><%#: Item.Provider %></strong>.  Please enter the code
               below to verify this provider.
            </p>

            <asp:ValidationSummary runat="server" CssClass="text-danger" />

            <div class="form-group">
               <asp:Label runat="server" AssociatedControlID="Code" CssClass="col-md-2 control-label">Code</asp:Label>
               <div class="col-md-4">
                  <asp:TextBox runat="server" ID="Code" CssClass="form-control" Text="<%# BindItem.Code %>" />
               </div>
            </div>
            <div class="form-group">
               <div class="col-md-offset-2 col-md-10">
                  <div class="checkbox">
                     <asp:CheckBox runat="server" ID="RememberBrowser" Checked="<%# BindItem.RememberBrowser %>" />
                     <asp:Label runat="server" AssociatedControlID="RememberBrowser">Remember browser?</asp:Label>
                  </div>
               </div>
            </div>
            <div class="form-group">
               <div class="col-md-offset-2 col-md-10">
                  <asp:Button runat="server" Text="Verify" CommandName="Update" CssClass="btn btn-primary" />
               </div>
            </div>
            
         <!-- Only display for demo purposes -->
         <asp:Panel runat="server" ID="pnlDemoOnly" Visible="<%# Item.IsDemo %>">
            <hr />
            <h3>Demo Purposes Only!</h3>
            <p>
               The following code is the same as the code sent to your account.
               Enter this code in the box above to simulate verification.
            </p>
            <p>
               Code:
               <strong>
                  <asp:Literal runat="server" ID="DemoCode" Text="<%# Item.DemoCode %>" Mode="Encode" />
               </strong>
            </p>
         </asp:Panel>

         </div>
      </EditItemTemplate>
   </asp:FormView>
</asp:Content>
