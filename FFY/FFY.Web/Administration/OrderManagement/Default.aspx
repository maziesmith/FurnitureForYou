<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FFY.Web.Administration.OrderManagement._Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br /><br />
    <asp:Label runat="server" Text="Show:" />
    <asp:DropDownList runat="server" AutoPostBack="true" ID="DisplayYear">
        <asp:ListItem Text="All" Value="" />
        <asp:ListItem Text="Freshman" />
        <asp:ListItem Text="Sophomore" />
        <asp:ListItem Text="Junior" />
        <asp:ListItem Text="Senior" />
    </asp:DropDownList>
    
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
            <asp:TemplateField HeaderText="Client">
                <ItemTemplate>
                    <asp:Literal ID="FullName" runat="server" Text='<%#Eval("User.FirstName")+ " " + Eval("User.LastName")%>' ></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="User.Email" HeaderText="Email" />
            <asp:BoundField DataField="SendOn" HeaderText="Send on" />
            <asp:BoundField DataField="OrderStatusType" HeaderText="Status" />
            <asp:HyperLinkField Text="Details" 
                DataNavigateUrlFields="Id"
                DataNavigateUrlFormatString="~/administration/orders/{0}"/>
        </Columns>
    </asp:GridView>
</asp:Content>
