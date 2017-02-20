<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserDetailed.aspx.cs" Inherits="FFY.Web.Administration.UserManagement.UserDetailed" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3><%# this.Model.User.FirstName %> <%# this.Model.User.LastName %></h3>
    <asp:HyperLink NavigateUrl="~/Account/ManagePassword" Text="Change Password" Visible="false" ID="ChangePassword" runat="server" />
    <hr />
    <div class="col-md-3">
        <asp:DropDownList runat="server" CssClass="form-control" ID="UsersDropdown">
            <asp:ListItem Text="User" Value="User"/>
            <asp:ListItem Text="Moderator" Value="Moderator"/>
            <asp:ListItem Text="Administrators" Value="Administrator"/>
        </asp:DropDownList>
    </div>
    <div>
        <asp:Button runat="server" OnClick="EditOrderStatus"/>
    </div>
    <asp:UpdatePanel ID="UserUpdate" runat="server" UpdateMode="Always" ChildrenAsTriggers="true">
        <ContentTemplate>
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
