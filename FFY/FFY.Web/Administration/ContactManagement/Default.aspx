<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FFY.Web.Administration.ContactManagement._Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="search-form">
      <div class="col-md-6 form-group">
            <div class="col-xs-12 col-sm-6">
                <asp:TextBox ID="SearchBox" CssClass="form-control" runat="server"></asp:TextBox>               
            </div>
            <div class="col-xs-12 col-sm-6">
            <asp:Button ID="SearchButton" Text="Search" runat="server"  CssClass="btn btn-primary btn-block" OnClick="SearchButtonClick"/>
            </div>
        </div>
        <div class="col-md-6 form-group">
            <div class="col-xs-offset-0 col-xs-12 col-md-offset-6 col-md-6">
                <asp:DropDownList runat="server" AutoPostBack="true" CssClass="form-control" ID="ContactsDropdown" OnSelectedIndexChanged="ContactsDropdownSelectedIndexChanged">
                    <asp:ListItem Text="All" Value="0" />
                    <asp:ListItem Text="Not proccessed" Value="1"/>
                    <asp:ListItem Text="Processing" Value="2"/>
                    <asp:ListItem Text="Proccessed" Value="3"/>
                </asp:DropDownList>
            </div>
        </div>
    </div>
<div class="list">
    <asp:UpdatePanel ID="OrderUpdate" runat="server" UpdateMode="Always" ChildrenAsTriggers="true">
        <Triggers>
            <asp:AsyncPostBackTrigger EventName="Click" ControlID="SearchButton" runat="server" />
        </Triggers>
        <Triggers>
            <asp:AsyncPostBackTrigger EventName="SelectedIndexChanged" ControlID="ContactsDropdown" runat="server" />
        </Triggers>
        <ContentTemplate>
            <asp:GridView ID="ContactList" AutoGenerateColumns="false" 
                ItemType="FFY.Models.Contact" 
                DataKeyNames="Id"  
                AllowPaging="true" 
                OnPageIndexChanging="ContactListPageIndexChanging" 
                EnableSortingAndPagingCallbacks="false" 
                PageSize="2"
                CssClass="table table-striped table-condensed table-bordered"
                DataKeyName="Id"
                runat="server">
                <Columns>
                    <asp:BoundField DataField="Title" HeaderText="Title"/>
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="SendOn" HeaderText="Send on" />
                    <asp:BoundField DataField="ContactStatusType" HeaderText="Status" />
                    <asp:HyperLinkField Text="Details" 
                        DataNavigateUrlFields="Id"
                        DataNavigateUrlFormatString="~/administration/contacts/{0}"/>
                </Columns>
                <PagerStyle CssClass="pagination-ys"/>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
</asp:Content>
