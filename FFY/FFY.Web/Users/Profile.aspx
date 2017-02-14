<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="FFY.Web.Users.Profile" %>

<asp:Content ID="ProfileContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3><%# this.Model.User.FirstName %> <%# this.Model.User.LastName %></h3>
</asp:Content>
