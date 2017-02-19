<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderDetailed.aspx.cs" Inherits="FFY.Web.Administration.OrderManagement.OrderDetailed" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%#: this.Model.Order.Id %>
    <hr />
    <%#: this.Model.Order.User.Email %>
    <hr />
    <%#: this.Model.Order.SendOn %>
    <hr />
    <%#: this.Model.Order.Total %>
</asp:Content>
