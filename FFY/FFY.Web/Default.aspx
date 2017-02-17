<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FFY.Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView ID="DiscountProducts" runat="server" DataKeyNames="Id"
        ItemType="FFY.Models.Product" >
        <ItemTemplate>
            <div class="col-md-3">
                <asp:HyperLink ID="RoomHyperLink" NavigateUrl='<%#: "~/furniture/product/" + Eval("Id") %>' runat="server">
                    <div>
                        <%#: Item.Name %>
                        <br />
                        <%#: Item.DiscountPercentage %>
                    </div>
                </asp:HyperLink>
            </div>
        </ItemTemplate>
    </asp:ListView>
    <br />
    <hr />
    <br />
    <asp:ListView ID="LatestProducts" runat="server" DataKeyNames="Id"
        ItemType="FFY.Models.Product" >
        <ItemTemplate>
            <div class="col-md-3">
                <asp:HyperLink ID="RoomHyperLink" NavigateUrl='<%#: "~/furniture/product/" + Eval("Id") %>' runat="server">
                    <div>
                        <%#: Item.Name %>
                    </div>
                </asp:HyperLink>
            </div>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
