<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ContactDetailed.aspx.cs" Inherits="FFY.Web.Administration.ContactManagement.ContactDetailed" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="contact">
        <div class="col-sm-4">
        <h6>Title</h6>
    </div>
    <div class="col-sm-4">
        <h6>Email</h6>
    </div>
    <div class="col-sm-4">
        <h6>Send on</h6>
    </div>
    <div class="col-sm-4">
        <h4>
            <%#: this.Model.Contact.Title %>
        </h4>
    </div>
    <div class="col-sm-4">
        <h4>
            <%#: this.Model.Contact.Email %>
        </h4>
    </div>
    <div class="col-sm-4">
        <h4>
            <%#: this.Model.Contact.SendOn%>
        </h4>
    </div>
    </div>
    <br />
    <hr />
    <br />
    <%#: this.Model.Contact.EmailContent %>
    <hr />
    <div class="status-form">
        <div class="col-md-6 form-group">
            <div class="col-xs-12 col-sm-6">
                <asp:DropDownList runat="server" ID="StatusType" CssClass="form-control">
                    <asp:ListItem Value="1" Text="Not Processed"></asp:ListItem>
                    <asp:ListItem Value="2" Text="Processing"></asp:ListItem>
                    <asp:ListItem Value="3" Text="Processed"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-xs-12 col-sm-6">
                <asp:Button runat="server" Text="Update" CssClass="btn btn-primary btn-block"  OnClick="EditContactStatus"/>
            </div>
        </div>
        <div class="col-md-6 form-group">
            <div class="col-xs-offset-0 col-xs-12 col-md-offset-6 col-md-6">
                <h4>
                    Proccessed by: <asp:Literal ID="ProccessedBy" runat="server"></asp:Literal>
                </h4>
            </div>
        </div>
    </div>
</asp:Content>
