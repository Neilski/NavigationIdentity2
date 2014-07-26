<%@ Page Title="Register External Login" Language="C#" MasterPageFile="~/Views/Shared/Layout.Master" AutoEventWireup="true" CodeBehind="ExternalLoginHandler.aspx.cs" Inherits="NavigationIdentity.Web.Views.Account.ExternalLoginHandler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <asp:FormView runat="server" RenderOuterTable="false"
      ItemType="NavigationIdentity.Web.Models.Account.ExternalLoginHandlerViewModel"
      DefaultMode="Edit"
      SelectMethod="GetExternalLoginHandler"
      UpdateMethod="ExternalLoginHandler"
      OnCallingDataMethods="GetAccountController">
      <EditItemTemplate>
         <div class="form-horizontal">
            <h2>Register External Login</h2>

            <p>
               You've authenticated with 
               <strong><%# Item.ProviderName %></strong>.
               Please enter a username and email address below to associate
               this provider with a local account.
            </p>

            <asp:ValidationSummary runat="server" CssClass="text-danger" />
            
            <asp:HiddenField runat="server" ID="ProviderName" Value="<%# Item.ProviderName %>"/>

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
            <div class="form-group">
               <div class="col-md-offset-2 col-md-10">
                  <asp:Button runat="server" Text="Register" CommandName="Update" CssClass="btn btn-primary" />
               </div>
            </div>
         </div>
      </EditItemTemplate>
   </asp:FormView>
</asp:Content>
