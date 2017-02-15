<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FFY.Web.Administration.UserManagement._Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="UserList" AutoGenerateColumns="false" ItemType="FFY.Models.User" 
        DataKeyNames="Id"  AllowPaging="true" OnPageIndexChanging="UserListPageIndexChanging" PageSize="2" BorderColor="White" BorderStyle="None" runat="server">
        <Columns>
            <asp:BoundField DataField="UserName" HeaderText="Username"/>
            <asp:BoundField DataField="FirstName" HeaderText="First Name" />
            <asp:BoundField DataField="LastName" HeaderText="Last Name" />
            <asp:BoundField DataField="Email" HeaderText="Email Address" />
            <asp:BoundField DataField="UserRole" HeaderText="Email Address" />
            <asp:ButtonField Text="Change Role" />
        </Columns>
    </asp:GridView>
</asp:Content>
