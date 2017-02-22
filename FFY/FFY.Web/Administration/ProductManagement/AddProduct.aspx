<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="FFY.Web.Administration.ProductManagement.AddProduct" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div class="form-horizontal">
        <h3>Product Addition</h3>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Name" CssClass="col-md-2 control-label">Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Name" CssClass="form-control" />  
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Name"
                    CssClass="text-danger" ErrorMessage="Name field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Price" CssClass="col-md-2 control-label">Price</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Price" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Price"
                    CssClass="text-danger" ErrorMessage="Price field is required." />
                 <asp:RangeValidator runat="server" ControlToValidate="Price" Type="Currency" MinimumValue="0" MaximumValue="100000" 
                    CssClass="text-danger" ErrorMessage="Price should be a number between 0 and 100000."></asp:RangeValidator>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="DiscountPercentage" CssClass="col-md-2 control-label">Discount percentage</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="DiscountPercentage" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="DiscountPercentage"
                    CssClass="text-danger" ErrorMessage="Discount percentage field is required." />
                 <asp:RangeValidator runat="server" ControlToValidate="DiscountPercentage" Type="Integer" MinimumValue="0" MaximumValue="100" 
                    CssClass="text-danger" ErrorMessage="Discount percentage should be a number between 0 and 100."></asp:RangeValidator>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Description" CssClass="col-md-2 control-label">Description</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Description" CssClass="form-control" TextMode="MultiLine" Rows="5" Columns="1" Wrap="true"/>  
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Description"
                    CssClass="text-danger" ErrorMessage="Description field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Rooms" CssClass="col-md-2 control-label">Room</asp:Label>
             <div class="col-md-3">
                <asp:DropDownList runat="server" ID="Rooms" CssClass="form-control" DataTextField="Name" DataValueField="Id"></asp:DropDownList>
             </div>
            <a runat="server" href="~/administration/productManagement/addRoom">Add new room</a>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Categories" CssClass="col-md-2 control-label">Category</asp:Label>
            <div class="col-md-3">
                <asp:DropDownList runat="server" ID="Categories" CssClass="form-control" DataTextField="Name" DataValueField="Id"></asp:DropDownList>
            </div>
            <a runat="server" href="~/administration/productManagement/addCategory">Add new category</a>

        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Image" CssClass="col-md-offset-2 col-md-3 btn btn-default">Browse</asp:Label>
                <asp:FileUpload runat="server" ID="Image" CssClass="form-control"></asp:FileUpload>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button Width="150px" runat="server" OnClick="AddProductClick" Text="Create" CssClass="btn btn-primary" />
            </div>
        </div>
    </div>
</asp:Content>
