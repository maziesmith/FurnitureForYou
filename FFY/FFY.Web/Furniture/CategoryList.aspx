<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CategoryList.aspx.cs" Inherits="FFY.Web.Furniture.CategoryList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView ID="RoomCategories" runat="server" DataKeyNames="Id"
        ItemType="FFY.Models.Category" >
        <ItemTemplate>
            <div class="col-md-3">
                <asp:HyperLink ID="CategoryHyperLink" NavigateUrl='<%#: $"~/furniture/{this.Model.Room}/{Eval("Name").ToString().ToLower().Replace(@"\s+", "")}" %>' runat="server">
                    <%#: Item.Name %>
                </asp:HyperLink>
            </div>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
