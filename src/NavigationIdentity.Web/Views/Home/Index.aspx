<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Views/Shared/Layout.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="NavigationIdentity.Web.Views.Home.Index" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   <div class="jumbotron">
      <h1>Navigation for ASP.NET</h1>
      <p class="lead">
         Microsoft's Identity version 2 Web Form implementation, with clean 
           mark&ndash;up and URLs using the Navigation for ASP.NET state
           management library.
      </p>
      <p>
         <a href="http://navigation.codeplex.com/" class="btn btn-primary btn-lg">Learn more &raquo;
         </a>
      </p>
   </div>

   <div class="row">
      <div class="col-md-12">
         This project can be implemented in three simple steps:
      </div>
   </div>

   <div class="row">
      <div class="col-md-4">
         <h3>Review Web.config</h3>
         <p>
            Update the application's Web.config file to:
         </p>
         <ul>
            <li>
               Configure SMTP service
            </li>
            <li>
               Configure SMS Service 
               (e.g. <a href="https://twilio.com">Twilio</a>)
            </li>
            <li>
               Adjust SQL connection string/data store
            </li>
            <li>
               Configure third&ndash;party authentication providers 
               (e.g. Google, Facebook, Twitter, Microsoft etc.)
            </li>
         </ul>
      </div>
      <div class="col-md-4">
         <h3>Adjust Identity configuration</h3>
         <p>
            Review and modify to suit, the code in the project's 
            <strong>/App_Start</strong> folder.
         </p>
         <ul>
            <li>
               IdentityStartup.Auth <span class="text-muted">&ndash; to
               register third&ndash; party authentication providers</span>
            </li>
            <li>
               ApplicationUserManagerFactory <span class="text-muted">&ndash;
               to configure security profile, password requirements etc.</span>
            </li>
         </ul>
      </div>
      <div class="col-md-4">
         <h3>Update configuration code</h3>
         <p>
            Review the code in the <strong>/Controllers/Account</strong>
            module.
         </p>
         <p>
            <em>Important</em>, you will need to comment out some of the 
            'demo only' code before publishing your web site.<br />
         </p>
         <p class="text-muted">
            <em>Tip:</em> search for the phrase 'DEMO-ONLY'.
         </p>
      </div>
   </div>

</asp:Content>
