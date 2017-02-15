<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FFY.Web.Furniture._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView ID="FurnitureRooms" runat="server" DataKeyNames="Id"
        ItemType="FFY.Models.Room" >
        <ItemTemplate>
            <div class="col-md-3">
                <asp:HyperLink ID="RoomHyperLink" NavigateUrl='<%#: "~/furniture/" + Eval("Name").ToString().ToLower().Replace(@"\s+", "") %>' runat="server">
                    <%#: Item.Name %>
                </asp:HyperLink>
            </div>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
