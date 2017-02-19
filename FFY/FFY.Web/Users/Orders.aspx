<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="FFY.Web.Users.Orders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
            <asp:GridView ID="OrderList" AutoGenerateColumns="false" 
        ItemType="FFY.Models.Order" 
        DataKeyNames="Id"  
        AllowPaging="true" 
        OnPageIndexChanging="OrderListPageIndexChanging" 
        PageSize="2"
        CssClass="table table-striped table-condensed table-bordered"
        runat="server">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id"/>
            <asp:BoundField DataField="User.Email" HeaderText="Email" />
            <asp:BoundField DataField="SendOn" HeaderText="Send on" />
            <asp:BoundField DataField="OrderStatusType" HeaderText="Status" />
            <asp:HyperLinkField Text="Details" 
                DataNavigateUrlFields="Id"
                DataNavigateUrlFormatString="~user/orders/{0}"/>
        </Columns>
    </asp:GridView>
</asp:Content>
