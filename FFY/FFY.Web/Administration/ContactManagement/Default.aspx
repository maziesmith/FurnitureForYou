<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FFY.Web.Administration.ContactManagement._Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="ContactList" AutoGenerateColumns="false" ItemType="FFY.Models.Contact" 
        DataKeyNames="Id"  AllowPaging="true" OnPageIndexChanging="ContactListPageIndexChanging" PageSize="2" BorderColor="White" BorderStyle="None" runat="server">
        <Columns>
            <asp:BoundField DataField="Title" HeaderText="Title"/>
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="SendOn" HeaderText="Send on" />
            <asp:BoundField DataField="ContactStatusType" HeaderText="Status" />
            <asp:ButtonField Text="Change Status" />
        </Columns>
    </asp:GridView>
</asp:Content>
