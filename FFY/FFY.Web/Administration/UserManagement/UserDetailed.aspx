<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserDetailed.aspx.cs" Inherits="FFY.Web.Administration.UserManagement.UserDetailed" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3><%# this.Model.User.FirstName %> <%# this.Model.User.LastName %></h3>
    <h5><%# this.Model.User.Email %></h5>
    <asp:HyperLink NavigateUrl="~/Account/ManagePassword" Text="Change Password" Visible="false" ID="ChangePassword" runat="server" />
    <hr />
    <div class="col-xs-12">
        <div class="col-sm-3">
            <asp:DropDownList runat="server" CssClass="form-control" ID="UsersDropdown">
                <asp:ListItem Text="User" Value="User"/>
                <asp:ListItem Text="Moderator" Value="Moderator"/>
                <asp:ListItem Text="Administrators" Value="Administrator"/>
            </asp:DropDownList>
        </div>
        <div class="col-sm-9">
            <div class="col-sm-4">
                <asp:Button ID="EditButton" Text="Update role" runat="server"  CssClass="btn btn-primary btn-block" OnClick="EditUserStatus"/>
            </div>
        </div>
    </div>
    <br />
    <br />
    <hr />
    <asp:UpdatePanel ID="OrderUpdate" runat="server" UpdateMode="Always" ChildrenAsTriggers="true">
        <ContentTemplate>
            <asp:GridView ID="OrderList" AutoGenerateColumns="false" 
                ItemType="FFY.Models.Order" 
                DataKeyNames="Id"  
                AllowPaging="true" 
                OnPageIndexChanging="OrderListPageIndexChanging" 
                EnableSortingAndPagingCallbacks="false" 
                PageSize="10"
                CssClass="table table-striped table-condensed table-bordered"
                DataKeyName="Id"
                runat="server">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id"/>
                    <asp:BoundField DataField="SendOn" HeaderText="Send on" />
                    <asp:BoundField DataField="Total" HeaderText="Total" />
                    <asp:BoundField DataField="OrderStatusType" HeaderText="Status" />
                    <asp:HyperLinkField Text="Details" 
                        DataNavigateUrlFields="Id"
                        DataNavigateUrlFormatString="~/administration/orders/{0}"/>
                </Columns>
                <PagerStyle CssClass="pagination-ys"/>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
