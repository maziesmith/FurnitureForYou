<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ContactDetailed.aspx.cs" Inherits="FFY.Web.Administration.ContactManagement.ContactDetailed" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%#: this.Model.Contact.Title %>
    <hr />
    <%#: this.Model.Contact.Email %>
    <hr />
    <%#: this.Model.Contact.SendOn %>
    <hr />
    <%#: this.Model.Contact.EmailContent %>
</asp:Content>
