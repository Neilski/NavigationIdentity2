<%@ Page Title="Register" Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="NavigationIdentity.Web.Views.Account.Register" MasterPageFile="~/Views/Shared/Layout.Master" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

   <asp:FormView runat="server" RenderOuterTable="false"
      ItemType="NavigationIdentity.Web.Models.Account.RegisterViewModel"
      DefaultMode="Insert" InsertMethod="Register" 
      OnCallingDataMethods="GetAccountController">
      <InsertItemTemplate>
         <h2>Register. <small>Create a new account.</small></h2>
         <div class="form-horizontal">
            <asp:ValidationSummary runat="server" CssClass="text-danger" />

            <div class="form-group">
               <asp:Label runat="server" AssociatedControlID="UserName" CssClass="col-md-3 control-label">Username</asp:Label>
               <div class="col-md-6">
                  <asp:TextBox runat="server" Placeholder="Username" ID="UserName" Text="<%# BindItem.UserName %>" CssClass="form-control" />
               </div>
            </div>
            <div class="form-group">
               <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-3 control-label">Email</asp:Label>
               <div class="col-md-6">
                  <asp:TextBox runat="server" Placeholder="Email" ID="Email" TextMode="Email" Text="<%# BindItem.Email %>" CssClass="form-control" />
               </div>
            </div>
            <div class="form-group">
               <asp:Label runat="server" AssociatedControlID="Title" CssClass="col-md-3 control-label">Title/First Name/Last Name</asp:Label>
               <div class="col-md-1">
                  <asp:TextBox runat="server" Placeholder="Title" ID="Title" Text="<%# BindItem.Title %>" CssClass="form-control" />
               </div>
               <div class="col-md-2">
                  <asp:TextBox runat="server" Placeholder="First name" ID="FirstName" Text="<%# BindItem.FirstName %>" CssClass="form-control" />
               </div>
               <div class="col-md-3">
                  <asp:TextBox runat="server" PlaceHolder="Last name" ID="LastName" Text="<%# BindItem.LastName %>" CssClass="form-control" />
               </div>
            </div>
            <div class="form-group">
               <asp:Label runat="server" AssociatedControlID="Gender" CssClass="col-md-3 control-label">Gender</asp:Label>
               <div class="col-md-3">
                  <asp:DropDownList runat="server" ID="Gender" 
                     ItemType="System.Web.UI.WebControls.ListItem" 
                     OnCallingDataMethods="GetAccountController" 
                     SelectMethod="GetGenderList" 
                     DataTextField="Text" DataValueField="Text" 
                     SelectedValue="<%# BindItem.Gender %>" CssClass="form-control" />
               </div>
            </div>
            <div class="form-group">
               <asp:Label runat="server" AssociatedControlID="DateOfBirth" CssClass="col-md-3 control-label">Date of Birth</asp:Label>
               <div class="col-md-3">
                  <asp:TextBox runat="server" Placeholder="1/1/2000" ID="DateOfBirth" TextMode="Date" Text="<%# BindItem.DateOfBirth %>" CssClass="form-control" />
               </div>
            </div>
            <hr />
            <div class="form-group">
               <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-3 control-label">Password</asp:Label>
               <div class="col-md-6">
                  <asp:TextBox runat="server" ID="Password" TextMode="Password" Text="<%# BindItem.Password %>" CssClass="form-control" />
               </div>
            </div>
            <div class="form-group">
               <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-3 control-label">Confirm password</asp:Label>
               <div class="col-md-6">
                  <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" Text="<%# BindItem.ConfirmPassword %>" CssClass="form-control" />
               </div>
            </div>
            <div class="form-group">
               <div class="col-md-offset-3 col-md-7">
                  <asp:Button runat="server" Text="Register" CommandName="Insert" CssClass="btn btn-primary" />
               </div>
            </div>
         </div>
      </InsertItemTemplate>
   </asp:FormView>
</asp:Content>
