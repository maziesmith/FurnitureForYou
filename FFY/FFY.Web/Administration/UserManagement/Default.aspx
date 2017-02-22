<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FFY.Web.Administration.UserManagement._Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="search-form">
      <div class="col-md-6 form-group">
            <div class="col-xs-12 col-sm-6">
                        <asp:TextBox ID="SearchBox" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-xs-12 col-sm-6">
                <asp:Button ID="SearchButton" Text="Search" runat="server" CssClass="btn btn-primary btn-block" OnClick="SearchButtonClick"/>
            </div>
        </div>
        <div class="col-md-6 form-group">
            <div class="col-xs-offset-0 col-xs-12 col-md-offset-6 col-md-6">
                <asp:DropDownList runat="server" AutoPostBack="true" CssClass="form-control" ID="UsersDropdown" OnSelectedIndexChanged="UsersDropdownSelectedIndexChanged">
                    <asp:ListItem Text="All" Value="0" />
                    <asp:ListItem Text="Users" Value="1"/>
                    <asp:ListItem Text="Moderators" Value="2"/>
                    <asp:ListItem Text="Administrators" Value="3"/>
                </asp:DropDownList>
            </div>
        </div>
    </div>
    <div class="list">
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
                    PageSize="10"
                    CssClass="table table-striped table-condensed"
                    DataKeyName="Id"
                    runat="server">
                    <Columns>
                        <asp:BoundField DataField="UserName" HeaderText="Username"/>
                        <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                        <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                        <asp:BoundField DataField="Email" HeaderText="Email" />
                        <asp:BoundField DataField="UserRole" HeaderText="Role" />
                        <asp:HyperLinkField Text="Details" 
                            DataNavigateUrlFields="Id"
                            DataNavigateUrlFormatString="~/administration/users/{0}"/>
                    </Columns>
                <PagerStyle CssClass="pagination-ys"/>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
     </div>
</asp:Content>
