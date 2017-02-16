<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditProduct.aspx.cs" Inherits="FFY.Web.Administration.ProductManagement.EditProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    Edit
    <div>Name: <%#: this.Model.Product.Name %> </div>
    <div>Price: <%#: this.Model.Product.Price %> </div>
    <div>Description: <%#: this.Model.Product.Description %> </div>
</asp:Content>
