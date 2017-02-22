<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FurnitureDetailed.aspx.cs" Inherits="FFY.Web.Furniture.FurnitureDetailed" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-xs-offset-0 col-xs-12 col-sm-offset-1 col-sm-11">
        <div class="col-md-4">
            <asp:Image class="img-responsive" ImageUrl='<%#: "~/Content/products/" + this.Model.Product.ImagePath + ".jpg" %>' runat="server"/>
        </div>
        <div class="col-md-8">
            <h1> <%#: this.Model.Product.Name %> </h1>
            <h4> <%#: this.Model.Product.Category.Name %> </h4>
            <h2> <%#: this.Model.Product.DiscountedPrice %> </h2>
            <h3>: <%#: this.Model.Product.Description %> </h3>
            <br />
            <div class="form-group">
                <div class="col-sm-3">
                    <asp:TextBox runat="server" ID="AddToCartQuantity" Text="1" CssClass="form-control" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator runat="server"
                        Type="Integer"
                        ControlToValidate="AddToCartQuantity"
                        MinimumValue="1"
                        MaximumValue="100"
                        ErrorMessage="Please provide positive quantity" />
                </div>
                <div class="col-sm-4">
                    <asp:Button ID="AddButton" runat="server" Text="Add to Cart" CssClass="btn btn-primary btn-block" OnClick="AddToCart"/>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
