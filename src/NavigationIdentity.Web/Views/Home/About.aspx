<%@ Page Title="About" Language="C#" MasterPageFile="~/Views/Shared/Layout.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="NavigationIdentity.Web.Views.Home.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <h2><%: Title %>.</h2>
   
   <p>
      This project uses Navigation for ASP.NET to tame Microsoft's Identity
      (version 2.0) Web Forms implementation.
   </p>
   
   <p>
      Find out more about&hellip;
   </p>
   
   <ul>
      <li>
         <a href="http://www.asp.net/identity">ASP.NET Identity</a>
      </li>
      <li>
         <a href="http://navigation.codeplex.com/">Navigation for ASP.NET</a>
      </li>
   </ul>
</asp:Content>
