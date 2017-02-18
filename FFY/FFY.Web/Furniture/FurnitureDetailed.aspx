<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FurnitureDetailed.aspx.cs" Inherits="FFY.Web.Furniture.FurnitureDetailed" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>Name: <%#: this.Model.Product.Name %> </div>
    <div>Price: <%#: this.Model.Product.Price %> </div>
    <div>Description: <%#: this.Model.Product.Description %> </div>

    <div>
        <asp:RangeValidator runat="server"
            Type="Integer"
            ControlToValidate="AddToCartQuantity"
            MinimumValue="1"
            MaximumValue="100"
            ErrorMessage="Please provide positive quantity" />
        <asp:TextBox runat="server" ID="AddToCartQuantity" Text="1" TextMode="Number"></asp:TextBox>
    </div>

    <asp:Button ID="add" Text="add" OnClick="AddToCart" runat="server"/>

</asp:Content>
