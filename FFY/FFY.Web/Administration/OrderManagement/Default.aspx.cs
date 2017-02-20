using FFY.MVP.Administration.OrderManagement.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace FFY.Web.Administration.OrderManagement
{
    [PresenterBinding(typeof(OrdersPresenter))]
    public partial class _Default : MvpPage<OrdersViewModel>, IOrdersView
    {
        public event EventHandler ListingOrders;
        public event EventHandler<FilterEventArgs> FilterOrders;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.ListingOrders?.Invoke(this, e);
                this.OrderList.DataSource = this.Model.Orders.ToList();
                this.OrderList.DataBind();
            }
        }

        protected void OrderListPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.Filter();
            // this.OrderList.DataSource = this.Model.Orders.ToList();
            this.OrderList.PageIndex = e.NewPageIndex;
            this.OrderList.DataBind();
        }

        protected void ContactsDropdownSelectedIndexChanged(object sender, EventArgs e)
        {
            this.Filter();
        }

        protected void SearchButtonClick(object sender, EventArgs e)
        {
            this.Filter();
        }

        private void Filter()
        {
            var statusType = int.Parse(this.ContactsDropdown.SelectedValue);
            this.FilterOrders?.Invoke(this, new FilterEventArgs(statusType, this.SearchBox.Text));
            this.OrderList.DataSource = this.Model.Orders.ToList();
            this.OrderList.DataBind();
        }
    }
}