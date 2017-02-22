<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderDetailed.aspx.cs" Inherits="FFY.Web.Administration.OrderManagement.OrderDetailed" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-sm-12">
        <div class="col-sm-4">
         <h4>Order ID: <%#: this.Model.Order.Id %></h4>
        </div>
        <div class="col-sm-4">
         <h4><%#: this.Model.Order.User.Email %></h4>
        </div>
        <div class="col-sm-4">
         <h4><%#: this.Model.Order.SendOn %></h4>  
        </div>
    </div>
    <br />
    <hr />
    <br />
    <% if(User.IsInRole("Administrator") || User.IsInRole("Moderator")) { %>
        <div class="form-group order-detailed">
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
            <div class="col-md-3">
                <asp:Button runat="server" Text="Update" CssClass="btn btn-primary btn-block"  OnClick="EditOrderStatus"/>
            </div>
            <div class="col-md-3"></div>
        </div>
    <% } %>
    <asp:GridView runat="server" ID="Products"
        AutoGenerateColumns="False"
        ItemType="FFY.Models.CartProduct"
        CssClass="table table-striped table-condensed table-bordered"
        DataKeyNames="ProductId">
        <Columns>
            <asp:BoundField DataField="Product.Name" HeaderText="Product" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
            <asp:BoundField DataField="Product.DiscountedPrice" HeaderText="Price"/>
            <asp:BoundField DataField="Total" HeaderText="Total"/>
        </Columns>
    </asp:GridView>
        <div class="col-md-5 col-md-offset-7 total">
        <h3>
            <asp:Label runat="server" ID="Total"></asp:Label>
        </h3>
    </div>
</asp:Content>
