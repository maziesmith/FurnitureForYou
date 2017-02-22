<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CategoryList.aspx.cs" Inherits="FFY.Web.Furniture.CategoryList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
         <div class="rooms-list col-xs-offset-0 col-xs-12 col-md-offset-1 col-md-10">
        <asp:ListView ID="CategoriesList" runat="server" DataKeyNames="Id"
            ItemType="FFY.Models.Category" >
            <ItemTemplate>
                <div class="col-xs-5 col-sm-5 col-md-2 product-wrapper">
                    <asp:HyperLink ID="HyperLink" NavigateUrl='<%#: $"~/furniture/{this.Model.Room}/{Eval("Name").ToString().ToLower().Replace(@"\s+", "")}" %>' runat="server">
                        <div class="image-wrapper">
                            <asp:Image class="img-responsive" ImageUrl='<%#:$"~/images/categories/{Eval("ImagePath")}"%>' runat="server"/>
                        </div>
                    </asp:HyperLink>
                     <div>
                        <asp:HyperLink ID="CategoryHyperLink" NavigateUrl='<%#: $"~/furniture/{this.Model.Room}/{Eval("Name").ToString().ToLower().Replace(@"\s+", "")}" %>' runat="server">
                        <h3>
                            <%#: Item.Name %>
                        </h3> 
                        </asp:HyperLink>
                    </div>  
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
