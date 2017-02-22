<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="FFY.Web.Users.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%#: $"{this.User.Identity.GetUserName()}'s Cart" %></h2>
    <hr />
    <asp:GridView runat="server" ID="Products"
        AutoGenerateColumns="False"
        ItemType="FFY.Models.CartProduct"
        CssClass="table table-striped table-condensed table-bordered"
        DataKeyNames="ProductId"
        OnRowDeleting="RemoveProduct">
        <Columns>
            <asp:BoundField DataField="Product.Name" HeaderText="Product" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
            <asp:BoundField DataField="Product.DiscountedPrice" HeaderText="Price"/>
            <asp:BoundField DataField="Total" HeaderText="Total"/>
           <asp:CommandField ShowDeleteButton="true"/>
        </Columns>
    </asp:GridView>
    <hr />
    <div class="col-md-7">
        <asp:HyperLink Width="150px" CssClass="btn btn-default" runat="server" Text="Check out" NavigateUrl="~/users/checkout"></asp:HyperLink>
    </div>
    <div class="col-md-5 total">
        <h3>
            <asp:Label runat="server" ID="Total"></asp:Label>
        </h3>
    </div>
    <br />
    <br />
</asp:Content>
