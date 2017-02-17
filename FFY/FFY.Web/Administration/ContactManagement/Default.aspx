<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FFY.Web.Administration.ContactManagement._Default" %>
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
    
    <asp:GridView ID="ContactList" AutoGenerateColumns="false" ItemType="FFY.Models.Contact" 
        DataKeyNames="Id"  AllowPaging="true" OnPageIndexChanging="ContactListPageIndexChanging" PageSize="2" BorderColor="White" BorderStyle="None" runat="server">
        <Columns>
            <asp:BoundField DataField="Title" HeaderText="Title"/>
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="SendOn" HeaderText="Send on" />
            <asp:BoundField DataField="ContactStatusType" HeaderText="Status" />
            <asp:HyperLinkField Text="Details" 
                DataNavigateUrlFields="Id"
                DataNavigateUrlFormatString="~/administration/contacts/{0}"/>
        </Columns>
    </asp:GridView>
</asp:Content>
