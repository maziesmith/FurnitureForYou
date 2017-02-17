<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FurnitureByRoom.aspx.cs" Inherits="FFY.Web.Furniture.FurnitureByRoom" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView ID="FurnitureProducts" runat="server" DataKeyNames="Id"
        ItemType="FFY.Models.Product" >
        <ItemTemplate>
            <div class="col-md-3">
                <asp:HyperLink ID="RoomHyperLink" NavigateUrl='<%#: "~/furniture/product/" + Eval("Id") %>' runat="server">
                    <%#: Item.Name %>
                </asp:HyperLink>
            </div>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
