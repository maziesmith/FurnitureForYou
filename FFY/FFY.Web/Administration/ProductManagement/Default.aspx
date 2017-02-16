<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FFY.Web.Administration.ProductManagement._Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <a runat="server" href="~/ProductManagement/AddProduct">Add product</a>
    </div>
    <hr />
    <div>
        <asp:ListView ID="FurnitureProducts" runat="server" DataKeyNames="Id"
            ItemType="FFY.Models.Product" >
            <ItemTemplate>
                <div class="col-md-12">
                    <asp:HyperLink ID="RoomHyperLink" NavigateUrl='<%#: "~/administration/edit-product/" + Eval("Id") %>' runat="server">
                        <div class="col-md-4">
                            <%#: Item.Name %>
                        </div>
                        <div class="col-md-4">
                            <%#: Item.Category.Name %>
                        </div>
                        <div class="col-md-4">
                            <%#: Item.ImagePath %>
                        </div>
                    </asp:HyperLink>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
