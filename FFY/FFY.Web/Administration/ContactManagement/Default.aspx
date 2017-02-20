<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FFY.Web.Administration.ContactManagement._Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br /><br />
    <div class="col-md-9">
        <div class="col-md-6">
            <asp:TextBox ID="SearchBox" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-3">
            <asp:Button ID="SearchButton" Text="Search" runat="server" OnClick="SearchButtonClick"/>
        </div>
    </div>
    <div class="col-md-3">
        <asp:DropDownList runat="server" AutoPostBack="true" CssClass="form-control" ID="ContactsDropdown" OnSelectedIndexChanged="ContactsDropdownSelectedIndexChanged">
            <asp:ListItem Text="All" Value="0" />
            <asp:ListItem Text="Not proccessed" Value="1"/>
            <asp:ListItem Text="Processing" Value="2"/>
            <asp:ListItem Text="Proccessed" Value="3"/>
        </asp:DropDownList>
    </div>
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
