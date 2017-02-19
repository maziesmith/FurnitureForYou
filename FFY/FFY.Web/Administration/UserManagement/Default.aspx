<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FFY.Web.Administration.UserManagement._Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <asp:GridView ID="UserList" AutoGenerateColumns="false" 
        ItemType="FFY.Models.User" 
        DataKeyNames="Id"  
        AllowPaging="true" 
        OnPageIndexChanging="UserListPageIndexChanging" 
        PageSize="2"
        CssClass="table table-striped table-condensed table-bordered"
        runat="server">
        <Columns>
            <asp:BoundField DataField="UserName" HeaderText="Username"/>
            <asp:TemplateField HeaderText="Client">
                <ItemTemplate>
                    <asp:Literal ID="FullName" runat="server" Text='<%#Eval("FirstName")+ " " + Eval("LastName")%>' ></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="UserRole" HeaderText="Role" />
            <asp:HyperLinkField Text="Details" 
                DataNavigateUrlFields="Id"
                DataNavigateUrlFormatString="~/administration/users/{0}"/>
        </Columns>
    </asp:GridView>
</asp:Content>
