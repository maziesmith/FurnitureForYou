<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FurnitureDetailed.aspx.cs" Inherits="FFY.Web.Furniture.FurnitureDetailed" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>Name: <%#: this.Model.Product.Name %> </div>
    <div>Price: <%#: this.Model.Product.Price %> </div>
    <div>Description: <%#: this.Model.Product.Description %> </div>

</asp:Content>
