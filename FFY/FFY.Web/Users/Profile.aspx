<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="FFY.Web.Users.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3><%# this.Model.User.FirstName %> <%# this.Model.User.LastName %></h3>
    <h5><%# this.Model.User.Email %></h5>
    <hr />
    <h4>
        <asp:HyperLink NavigateUrl="~/Account/ManagePassword" Text="Change Password" ID="ChangePassword" runat="server" />
    </h4>
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
                        DataNavigateUrlFormatString="~user/orders/{0}"/>
                </Columns>
                <PagerStyle CssClass="pagination-ys"/>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

