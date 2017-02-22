<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FFY.Web.Administration.ProductManagement._Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="indented">
        <h3>
            <asp:HyperLink Text="Add new product" NavigateUrl="~/administration/productManagement/addProduct" runat="server"></asp:HyperLink>
        </h3>
    </div>
    <hr />
    <div class="search-form">
      <div class="col-md-6 form-group">
            <div class="col-xs-12 col-sm-6">
                <asp:TextBox ID="SearchBox" CssClass="form-control" runat="server"></asp:TextBox>              
            </div>
            <div class="col-xs-12 col-sm-6">
                <asp:Button ID="SearchButton" Text="Search" runat="server" CssClass="btn btn-primary btn-block" OnClick="SearchButtonClick"/>
            </div>
        </div>
    </div>
    <div class="list">
        <asp:UpdatePanel ID="OrderUpdate" runat="server" UpdateMode="Always" ChildrenAsTriggers="true">
            <Triggers>
                <asp:AsyncPostBackTrigger EventName="Click" ControlID="SearchButton" runat="server" />
            </Triggers>
            <ContentTemplate>
                <asp:GridView ID="ProductList" AutoGenerateColumns="false" 
                    ItemType="FFY.Models.Product" 
                    DataKeyNames="Id"  
                    AllowPaging="true" 
                    OnPageIndexChanging="ProductListPageIndexChanging" 
                    EnableSortingAndPagingCallbacks="false" 
                    PageSize="10"
                    CssClass="table table-striped table-condensed table-bordered"
                    DataKeyName="Id"
                    runat="server">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id"/>
                        <asp:BoundField DataField="Name" HeaderText="Name" />
                        <asp:BoundField DataField="Price" HeaderText="Price" />
                        <asp:BoundField DataField="DiscountPercentage" HeaderText="Discount Percentage" />
                        <asp:BoundField DataField="Room.Name" HeaderText="Room" />
                        <asp:BoundField DataField="Category.Name" HeaderText="Category" />
                        <asp:HyperLinkField Text="Edit" 
                            DataNavigateUrlFields="Id"
                            DataNavigateUrlFormatString="~/administration/edit-product/{0}"/>
                    </Columns>
                <PagerStyle CssClass="pagination-ys"/>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
