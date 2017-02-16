﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditProduct.aspx.cs" Inherits="FFY.Web.Administration.ProductManagement.EditProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal">
        <h3>Product Addition</h3>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Name" CssClass="col-md-2 control-label">Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Name" Text="<%#: this.Model.Product.Name %>" CssClass="form-control" />  
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Name"
                    CssClass="text-danger" ErrorMessage="Name field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Price" CssClass="col-md-2 control-label">Price</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Price" Text="<%#: this.Model.Product.Price %>" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Price"
                    CssClass="text-danger" ErrorMessage="Price field is required." />
                 <asp:RangeValidator runat="server" ControlToValidate="Price" Type="Double" MinimumValue="0" MaximumValue="100000" 
                    CssClass="text-danger" ErrorMessage="Price must be a number between 0 and 100000."></asp:RangeValidator>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Description" CssClass="col-md-2 control-label">Description</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Description" Text="<%#: this.Model.Product.Description %>" CssClass="form-control" TextMode="MultiLine" Rows="5" Columns="1" Wrap="true"/>  
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Description"
                    CssClass="text-danger" ErrorMessage="Description field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Rooms" CssClass="col-md-2 control-label">Room</asp:Label>
             <div class="col-md-3">
                <asp:DropDownList runat="server" ID="Rooms" CssClass="form-control" DataTextField="Name" DataValueField="Id"></asp:DropDownList>
             </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Categories" CssClass="col-md-2 control-label">Category</asp:Label>
            <div class="col-md-3">
                <asp:DropDownList runat="server" ID="Categories" CssClass="form-control" DataTextField="Name" DataValueField="Id"></asp:DropDownList>
            </div>
            <a runat="server" href="~/administration/productManagement/addCategory">Add new category</a>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Image" CssClass="col-md-2 control-label">Image</asp:Label>
            <div class="col-md-3">
                <asp:FileUpload runat="server" ID="Image" CssClass="form-control"></asp:FileUpload>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="EditProductClick" Text="Save" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
    <div>Name: <%#: this.Model.Product.Name %> </div>
    <div>Price: <%#: this.Model.Product.Price %> </div>
    <div>Description: <%#: this.Model.Product.Description %> </div>
</asp:Content>
