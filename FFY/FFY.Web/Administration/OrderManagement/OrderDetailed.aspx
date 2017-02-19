<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderDetailed.aspx.cs" Inherits="FFY.Web.Administration.OrderManagement.OrderDetailed" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%#: this.Model.Order.Id %>
    <hr />
    <%#: this.Model.Order.User.Email %>
    <hr />
    <%#: this.Model.Order.SendOn %>
    <hr />
    <div class="form-group">
        <div class="col-md-3">
            <asp:DropDownList runat="server" ID="StatusType" CssClass="form-control">
                <asp:ListItem Value="1" Text="Processing"></asp:ListItem>
                <asp:ListItem Value="2" Text="Sent"></asp:ListItem>
                <asp:ListItem Value="3" Text="Delivered"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-md-3">
            <asp:DropDownList runat="server" ID="PaymentStatusType" CssClass="form-control">
                <asp:ListItem Value="1" Text="Payed"></asp:ListItem>
                <asp:ListItem Value="2" Text="Payment on Delivery"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-md-6">
            <asp:Button runat="server" Text="Update" OnClick="EditOrderStatus"/>
        </div>
    </div>
    <hr />
    <asp:GridView runat="server" ID="Products"
        AutoGenerateColumns="False"
        ItemType="FFY.Models.CartProduct"
        CssClass="table table-striped table-condensed table-bordered"
        DataKeyNames="ProductId">
        <Columns>
            <asp:BoundField DataField="Product.Name" HeaderText="Product" />
            <asp:BoundField DataField="Quantity" HeaderText="Category" />
            <asp:BoundField DataField="Product.DiscountedPrice" HeaderText="Category"/>
            <asp:BoundField DataField="Total" HeaderText="Category"/>
           <asp:CommandField ShowDeleteButton="true"/>
        </Columns>
    </asp:GridView>
    <asp:Label runat="server" ID="Total"></asp:Label>
</asp:Content>
