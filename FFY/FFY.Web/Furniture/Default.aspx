<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FFY.Web.Furniture._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <div class="rooms-list col-xs-offset-0 col-xs-12 col-md-offset-1 col-md-10">
        <asp:ListView ID="FurnitureRooms" runat="server" DataKeyNames="Id"
            ItemType="FFY.Models.Room" >
            <ItemTemplate>
                <div class="col-xs-5 col-sm-5 col-md-2 product-wrapper">
                    <asp:HyperLink ID="HyperLink1" NavigateUrl='<%#: $"~/furniture/{Eval("Name")}"%>' runat="server">
                        <div class="image-wrapper">
                            <asp:Image class="img-responsive" ImageUrl='<%#: $"~/images/rooms/{Eval("ImagePath")}"%>' runat="server"/>
                        </div>
                    </asp:HyperLink>
                     <div>
                        <asp:HyperLink ID="RoomHyperLink" NavigateUrl='<%#: $"~/furniture/{Eval("Name")}" %>' runat="server">
                        <h3>
                            <%#: Item.Name %>
                        </h3> 
                        </asp:HyperLink>
                    </div>  
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
