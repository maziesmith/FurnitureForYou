<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CheckOut.aspx.cs" Inherits="FFY.Web.Users.CheckOut" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal center-form">
        <h3 class="checkout">Checkout</h3>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Street" CssClass="col-md-2 control-label">Street</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Street" CssClass="form-control" />  
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Street"
                    CssClass="text-danger" ErrorMessage="Street field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="City" CssClass="col-md-2 control-label">City</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="City" CssClass="form-control" />  
                <asp:RequiredFieldValidator runat="server" ControlToValidate="City"
                    CssClass="text-danger" ErrorMessage="City field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Country" CssClass="col-md-2 control-label">Country</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Country" CssClass="form-control" />  
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Country"
                    CssClass="text-danger" ErrorMessage="Country field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="PhoneNumber" CssClass="col-md-2 control-label">Phone number</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="PhoneNumber" CssClass="form-control" />  
                <asp:RequiredFieldValidator runat="server" ControlToValidate="PhoneNumber"
                    CssClass="text-danger" ErrorMessage="Phone number field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="PaymentTypeSelection" CssClass="col-md-2 control-label">Payment type</asp:Label>
            <div class="col-md-10">
                    <asp:RadioButtonList ID="PaymentTypeSelection"  runat="server">
                        <asp:ListItem Text="On Delivery"></asp:ListItem>
                        <asp:ListItem Text="PayPal"></asp:ListItem>
                        <asp:ListItem Text="CreditCard"></asp:ListItem>
                    </asp:RadioButtonList>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button Width="150px" runat="server" OnClick="CheckOutOrder" Text="Finish" CssClass="btn btn-primary" />
            </div>
        </div>
        <hr />
    </div>
        <asp:HyperLink Text="Go back" NavigateUrl="~/users/cart" runat="server"></asp:HyperLink>

</asp:Content>
