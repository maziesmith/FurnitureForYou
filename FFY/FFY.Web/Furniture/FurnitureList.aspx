<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FurnitureList.aspx.cs" Inherits="FFY.Web.Furniture.FurnitureList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-12">
        <div class="col-md-4">
            <asp:TextBox ID="SearchBox" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-2">
            <asp:TextBox ID="FromBox" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-2">
            <asp:TextBox ID="ToBox" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-2">
            <asp:Button ID="Search" runat="server" Text="Search" OnClick="SearchClick"/>
        </div>
    </div> 
    
    <asp:ListView ID="Products" ItemType="FFY.Models.Product" runat="server">
        <ItemTemplate>
            <div class="col-md-3">
                <%#: Item.Name %>
                <br />
                <%#: Item.DiscountedPrice %>
                <br />
                <%#: Item.DiscountPercentage %>
            </div>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
