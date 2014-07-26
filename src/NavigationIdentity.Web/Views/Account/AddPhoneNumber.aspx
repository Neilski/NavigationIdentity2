<%@ Page Title="Add Phone Number" Language="C#" MasterPageFile="~/Views/Shared/Layout.Master" AutoEventWireup="true" CodeBehind="AddPhoneNumber.aspx.cs" Inherits="NavigationIdentity.Web.Views.Account.AddPhoneNumber" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <asp:FormView runat="server" RenderOuterTable="false"
      ItemType="NavigationIdentity.Web.Models.Account.AddPhoneNumberViewModel" 
      DefaultMode="Insert" InsertMethod="AddPhoneNumber" 
      OnCallingDataMethods="GetAccountController">
      <InsertItemTemplate>
         <div class="form-horizontal">
            <h2>Add Phone Number</h2>

            <asp:ValidationSummary runat="server" CssClass="text-danger" />

            <div class="form-group">
               <asp:Label runat="server" AssociatedControlID="PhoneNumber" CssClass="col-md-2 control-label">Phone Number</asp:Label>
               <div class="col-md-4">
                  <asp:TextBox runat="server" ID="PhoneNumber" CssClass="form-control" TextMode="Phone" Text="<%# BindItem.PhoneNumber %>" />
               </div>
            </div>
            <div class="form-group">
               <div class="col-md-offset-2 col-md-10">
                  <asp:Button runat="server" Text="Add Number" CommandName="Insert" CssClass="btn btn-primary" />
               </div>
            </div>
         </div>
      </InsertItemTemplate>
   </asp:FormView>
</asp:Content>
