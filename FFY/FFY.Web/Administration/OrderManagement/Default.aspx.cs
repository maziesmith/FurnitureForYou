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

        protected void Page_Load(object sender, EventArgs e)
        {
            this.ListingOrders?.Invoke(this, e);

            if (!Page.IsPostBack)
            {
                this.OrderList.DataSource = this.Model.Orders.ToList();
                this.OrderList.DataBind();
            }
        }

        protected void OrderListPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.OrderList.PageIndex = e.NewPageIndex;
            this.OrderList.DataBind();
        }
    }
}