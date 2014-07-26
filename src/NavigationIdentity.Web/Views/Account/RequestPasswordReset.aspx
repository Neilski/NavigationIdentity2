<%@ Page Title="Request Password Reset" Language="C#" MasterPageFile="~/Views/Shared/Layout.Master" AutoEventWireup="true" CodeBehind="RequestPasswordReset.aspx.cs" Inherits="NavigationIdentity.Web.Views.Account.RequestPasswordReset" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <asp:FormView runat="server" RenderOuterTable="false"
      ItemType="NavigationIdentity.Web.Models.Account.RequestPasswordResetViewModel"
      DefaultMode="Insert" InsertMethod="RequestPasswordReset"
      OnCallingDataMethods="GetAccountController">
      <InsertItemTemplate>
         <div class="form-horizontal">
            <h2>Request Password Reset.</h2>

            <asp:ValidationSummary runat="server" CssClass="text-danger" />

            <div class="form-group">
               <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email Address</asp:Label>
               <div class="col-md-4">
                  <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" Text="<%# BindItem.Email %>" />
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
