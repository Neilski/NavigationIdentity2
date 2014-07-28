<%@ Page Title="Update Personal Details" Language="C#" MasterPageFile="~/Views/Shared/Layout.Master" AutoEventWireup="true" CodeBehind="UpdatePersonalDetails.aspx.cs" Inherits="NavigationIdentity.Web.Views.Account.UpdatePersonalDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <asp:FormView runat="server" RenderOuterTable="false"
      ItemType="NavigationIdentity.Web.Models.Account.PersonalDetailsViewModel"
      DefaultMode="Edit"
      SelectMethod="GetPersonalDetails"
      UpdateMethod="UpdatePersonalDetails"
      OnCallingDataMethods="GetAccountController">
      <EditItemTemplate>
         <div class="form-horizontal">
            <h2>Update Personal Details.</h2>

            <asp:ValidationSummary runat="server" CssClass="text-danger" />
            
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
                  <asp:Button runat="server" Text="Save" CommandName="Update" CssClass="btn btn-primary" />
               </div>
            </div>
         </div>
      </EditItemTemplate>
   </asp:FormView>
</asp:Content>

