<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="FFY.Web.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal center-form">
            <h2>Contact us</h2>
            <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email Address</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Email" CssClass="form-control" />  
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                    CssClass="text-danger" ErrorMessage="Email Address field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="EmailTitle" CssClass="col-md-2 control-label">Title</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="EmailTitle" CssClass="form-control" />  
                <asp:RequiredFieldValidator runat="server" ControlToValidate="EmailTitle"
                    CssClass="text-danger" ErrorMessage="Title field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="EmailContent" CssClass="col-md-2 control-label"></asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="EmailContent" CssClass="form-control" TextMode="MultiLine" Rows="5" Columns="1" Wrap="true"/>  
                <asp:RequiredFieldValidator runat="server" ControlToValidate="EmailContent"
                    CssClass="text-danger" ErrorMessage="Email content is required." />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button Width="150px" runat="server" OnClick="SendContactClick" Text="Send" CssClass="btn btn-default" />
            </div>
        </div>
    </div>

</asp:Content>
