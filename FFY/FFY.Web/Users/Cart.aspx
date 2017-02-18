<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="FFY.Web.Users.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView runat="server" ID="Products"
        AutoGenerateColumns="False"
        ItemType="FFY.Models.CartProduct"
        CssClass="table table-striped table-condensed table-bordered"
        DataKeyNames="ProductId"
        OnRowDeleting="RemoveProduct">
        <Columns>
            <asp:BoundField DataField="Product.Name" HeaderText="Product" />
            <asp:BoundField DataField="Quantity" HeaderText="Category" />
            <asp:BoundField DataField="Product.DiscountedPrice" HeaderText="Category"/>
            <asp:BoundField DataField="Total" HeaderText="Category"/>
           <asp:CommandField ShowDeleteButton="true"/>
        </Columns>
    </asp:GridView>
    <asp:Label runat="server" ID="Total"></asp:Label>
    <asp:HyperLink runat="server" Text="Check out" NavigateUrl="~/users/checkout"></asp:HyperLink>
</asp:Content>
