<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FFY.Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1> Discounts </h1>
    <hr />
    <div class="front-product col-xs-offset-0 col-xs-12 col-md-offset-1 col-md-10">
        <asp:ListView ID="DiscountProducts" runat="server" DataKeyNames="Id"
            ItemType="FFY.Models.Product" >
            <ItemTemplate>
                <div class="col-xs-5 col-sm-5 col-md-2 product-wrapper">
                    <asp:HyperLink ID="HyperLink1" NavigateUrl='<%#: "~/furniture/product/" + Eval("Id") %>' runat="server">
                        <div class="image-wrapper">
                            <asp:Image class="img-responsive" ImageUrl='<%#: "~/images/products/" + Eval("ImagePath")%>' runat="server"/>
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
                        <div class="discount-tag">
                            <h3>
                                <%#: Item.DiscountPercentage %>% off
                            </h3>
                        </div>
                    </div>  
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>
    <h3 class="view-more-link">
        <asp:HyperLink Text="View more" ID="DiscountProductsHyper" NavigateUrl="~/furniture/discount" runat="server" />
    </h3>
        <h1> Latest </h1>
    <hr />
    <div class="front-product col-xs-offset-0 col-xs-12 col-md-offset-1 col-md-10">
        <asp:ListView ID="LatestProducts" runat="server" DataKeyNames="Id"
            ItemType="FFY.Models.Product" >
            <ItemTemplate>
                <div class="col-xs-5 col-sm-5 col-md-2 product-wrapper">
                    <asp:HyperLink ID="HyperLink1" NavigateUrl='<%#: $"~/furniture/product/{Eval("Id")}"%>' runat="server">
                        <div class="image-wrapper">
                            <asp:Image class="img-responsive" ImageUrl='<%#: $"~/images/products/{Eval("ImagePath")}"%>' runat="server"/>
                        </div>
                    </asp:HyperLink>
                     <div>
                        <asp:HyperLink ID="RoomHyperLink" NavigateUrl='<%#:$"~/furniture/product/{Eval("Id")}"%>' runat="server">
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
                    </div>  
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>
    <h3 class="view-more-link">
        <asp:HyperLink Text="View more" ID="HyperLink2" NavigateUrl="~/furniture/latest" runat="server" />
    </h3>
</asp:Content>
