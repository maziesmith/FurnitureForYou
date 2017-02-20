<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FFY.Web.Administration.UserManagement._Default" %>
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
        <asp:DropDownList runat="server" AutoPostBack="true" CssClass="form-control" ID="UsersDropdown" OnSelectedIndexChanged="UsersDropdownSelectedIndexChanged">
            <asp:ListItem Text="All" Value="0" />
            <asp:ListItem Text="Users" Value="1"/>
            <asp:ListItem Text="Moderators" Value="2"/>
            <asp:ListItem Text="Administrators" Value="3"/>
        </asp:DropDownList>
    </div>
    
<asp:UpdatePanel ID="UserUpdate" runat="server" UpdateMode="Always" ChildrenAsTriggers="true">
    <Triggers>
        <asp:AsyncPostBackTrigger EventName="Click" ControlID="SearchButton" runat="server" />
    </Triggers>
    <Triggers>
        <asp:AsyncPostBackTrigger EventName="SelectedIndexChanged" ControlID="UsersDropdown" runat="server" />
    </Triggers>
    <ContentTemplate>
        <asp:GridView ID="UserList" AutoGenerateColumns="false" 
            ItemType="FFY.Models.User" 
            DataKeyNames="Id"  
            AllowPaging="true" 
            OnPageIndexChanging="UserListPageIndexChanging" 
            EnableSortingAndPagingCallbacks="false" 
            PageSize="2"
            CssClass="table table-striped table-condensed table-bordered"
            DataKeyName="Id"
            runat="server">
            <Columns>
                <asp:BoundField DataField="UserName" HeaderText="Username"/>
                <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="UserRole" HeaderText="Role" />
                <asp:HyperLinkField Text="Details" 
                    DataNavigateUrlFields="Id"
                    DataNavigateUrlFormatString="~/administration/users/{0}"/>
            </Columns>
        </asp:GridView>
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
