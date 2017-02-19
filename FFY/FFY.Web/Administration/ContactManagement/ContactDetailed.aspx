<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ContactDetailed.aspx.cs" Inherits="FFY.Web.Administration.ContactManagement.ContactDetailed" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%#: this.Model.Contact.Title %>
    <hr />
    <%#: this.Model.Contact.Email %>
    <hr />
    <%#: this.Model.Contact.SendOn %>
    <hr />
    <%#: this.Model.Contact.EmailContent %>
    <hr />
    <asp:Literal ID="ProccessedBy" runat="server"></asp:Literal>
        <div class="form-group">
        <div class="col-md-3">
            <asp:DropDownList runat="server" ID="StatusType" CssClass="form-control">
                <asp:ListItem Value="1" Text="Not Processed"></asp:ListItem>
                <asp:ListItem Value="2" Text="Processing"></asp:ListItem>
                <asp:ListItem Value="3" Text="Processed"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-md-6">
            <asp:Button runat="server" Text="Update" OnClick="EditContactStatus"/>
        </div>
    </div>
</asp:Content>
