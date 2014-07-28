<%@ Page Title="Verify Phone Number" Language="C#" MasterPageFile="~/Views/Shared/Layout.Master" AutoEventWireup="true" CodeBehind="VerifyPhoneNumber.aspx.cs" Inherits="NavigationIdentity.Web.Views.Account.VerifyPhoneNumber" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <asp:FormView runat="server" 
      ItemType="NavigationIdentity.Web.Models.Account.VerifyPhoneNumberViewModel"
      DefaultMode="Edit" 
      DataKeyNames="PhoneNumber"
      SelectMethod="GetVerifyPhoneNumber" 
      UpdateMethod="VerifyPhoneNumber"
      OnCallingDataMethods="GetAccountController" RenderOuterTable="false">
      <EditItemTemplate>
         <div class="form-horizontal">
            <h2>Verify Phone Number</h2>

            <asp:ValidationSummary runat="server" CssClass="text-danger" />

            <div class="form-group">
               <asp:Label runat="server" AssociatedControlID="Code" CssClass="col-md-2 control-label">Code</asp:Label>
               <div class="col-md-4">
                  <asp:TextBox runat="server" ID="Code" CssClass="form-control" Text="<%# BindItem.Code %>" />
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
               The following code is the same as the code sent via SMS to your
               phone.  Enter this code in the box above to simulate phone
               verification.
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
