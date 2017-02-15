<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Furniture.aspx.cs" Inherits="FFY.Web.Furniture" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView ID="FurnitureRooms" runat="server" DataKeyNames="Id"
        ItemType="FFY.Models.Room" >
        <ItemTemplate>
            <div class="col-md-3">
                <a runat="server" href='<%#: "~/Furniture/" + Eval("Name") %>'><%#: Item.Name %></a>
            </div>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
