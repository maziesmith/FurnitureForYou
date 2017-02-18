<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="FFY.Web.Users.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView runat="server" ID="Products"
        AutoGenerateColumns="False"
        ItemType="FFY.Models.CartProduct"
        CssClass="table table-striped table-condensed table-bordered"
        DataKeyNames="ProductId">
        <Columns>
            <asp:BoundField DataField="Product.Name" HeaderText="Product" />
            <asp:BoundField DataField="Product.Price" HeaderText="Price" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
            <asp:CommandField ShowDeleteButton="true" />
        </Columns>
    </asp:GridView>
    <asp:Label runat="server" ID="Total"></asp:Label>
</asp:Content>
