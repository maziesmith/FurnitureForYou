<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FurnitureList.aspx.cs" Inherits="FFY.Web.Furniture.FurnitureList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="search-form">
      <div class="col-md-6 form-group">
            <div class="col-xs-12 col-sm-6">
                <asp:TextBox Placeholder="Search" runat="server" ID="SearchBox" CssClass="form-control"/>
            </div>
            <div class="col-xs-12 col-sm-6">
                <asp:Button ID="Search" runat="server" Text="Search" CssClass="btn btn-primary btn-block" OnClick="SearchClick"/>
            </div>
        </div>
        <div class="col-md-6 form-group">
            <div class="col-sm-6 vertical-align-label">
                <asp:Label Text="In price range" runat="server" CssClass="control-label" AssociatedControlID="FromBox"></asp:Label>
            </div>
            <div class="col-sm-3">
                <asp:TextBox Placeholder="From" ID="FromBox" TextMode="Number" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-sm-3">
                <asp:TextBox Placeholder="To" ID="ToBox" TextMode="Number" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
    </div>

    <div class="front-product fl col-xs-offset-0 col-xs-12 col-md-offset-1 col-md-10">
        <asp:ListView ID="Products" runat="server" DataKeyNames="Id"
            ItemType="FFY.Models.Product">
            <ItemTemplate>
                <div class="col-xs-5 col-sm-5 col-md-2 product-wrapper">
                    <asp:HyperLink ID="HyperLink1" NavigateUrl='<%#: "~/furniture/product/" + Eval("Id") %>' runat="server">
                        <div class="image-wrapper">
                            <asp:Image class="img-responsive" ImageUrl='<%#: "~/Images/products/" + Eval("ImagePath")%>' runat="server"/>
                        </div>
                    </asp:HyperLink>
                     <div>
                        <asp:HyperLink ID="RoomHyperLink" NavigateUrl='<%#: "~/furniture/product/" + Eval("Id") %>' runat="server">
                        <h3>
                            <%#: Item.Name %>
                        </h3> 
                        </asp:HyperLink>
                        <h5>
                            price: <%#: Item.Price %>
                        </h5>
                        <h4>
                            New price: <%#: Item.DiscountedPrice %>
                        </h4>
                        <% if(HttpContext.Current.Request.Url.AbsolutePath.Contains("furniture/discount")) { %>
                            <div class="discount-tag">
                                <h3>
                                    <%#: Item.DiscountPercentage %>% off
                                </h3>
                            </div>
                        <% } %>
                    </div>  
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
