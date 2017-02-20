<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FFY.Web.Administration.ProductManagement._Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <a runat="server" href="~/administration/productManagement/addProduct">Add product</a>
    </div>
    <hr />

    <br /><br />
        <div class="col-md-9">
            <div class="col-md-6">
                <asp:TextBox ID="SearchBox" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:Button ID="SearchButton" Text="Search" runat="server" OnClick="SearchButtonClick"/>
            </div>
        </div>
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
                PageSize="4"
                CssClass="table table-striped table-condensed table-bordered"
                DataKeyName="Id"
                runat="server">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id"/>
                    <asp:BoundField DataField="Name" HeaderText="Email" />
                    <asp:BoundField DataField="Price" HeaderText="Email" />
                    <asp:HyperLinkField Text="Edit" 
                        DataNavigateUrlFields="Id"
                        DataNavigateUrlFormatString="~/administration/edit-product/{0}"/>
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
