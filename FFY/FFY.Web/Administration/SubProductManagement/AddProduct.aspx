<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="FFY.Web.Administration.SubProductManagement.AddProduct" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div class="form-horizontal">
        <h3>Create your advertisement</h3>
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
                 <asp:RangeValidator runat="server" ControlToValidate="Price" Type="Double" MinimumValue="0" MaximumValue="100000" 
                    CssClass="text-danger" ErrorMessage="Price must be a number between 0 and 100000."></asp:RangeValidator>
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
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Categories" CssClass="col-md-2 control-label">Category</asp:Label>
            <div class="col-md-3">
                <asp:DropDownList runat="server" ID="Categories" CssClass="form-control" DataTextField="Name" DataValueField="Id"></asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Image" CssClass="col-md-2 control-label">Image</asp:Label>
            <div class="col-md-3">
                <asp:FileUpload runat="server" ID="Image" CssClass="form-control"></asp:FileUpload>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="Unnamed_Click" Text="Create" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>
