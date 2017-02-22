using FFY.MVP.OrderManagement.OrderDetailed;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace FFY.Web.Administration.OrderManagement
{
    [PresenterBinding(typeof(OrderDetailedPresenter))]
    public partial class OrderDetailed : MvpPage<OrderDetailedViewModel>, IOrderDetailedView
    {
        public event EventHandler<EditOrderStatusEventArgs> EdittingOrderStatus;
        public event EventHandler<GetOrderByIdEventArgs> Initial;

        protected void Page_Load(object sender, EventArgs e)
        {
            string orderIdParameter = null;

            if (this.Page.RouteData.Values["orderId"] != null)
            {
                orderIdParameter = this.Page.RouteData.Values["orderId"].ToString();
            }

            int orderId;

            if (!(int.TryParse(orderIdParameter, out orderId)))
            {
                this.Server.Transfer("~/Errors/PageNotFound.aspx");
            }

            this.Initial?.Invoke(this, new GetOrderByIdEventArgs(orderId));

            if (this.Model.Order == null)
            {
                this.Server.Transfer("~/Errors/PageNotFound.aspx");
            }

            if (this.Model.Order.User.Id != this.User.Identity.GetUserId()
                && !this.User.IsInRole("Administrator")
                && !this.User.IsInRole("Moderator"))
            {
                this.Server.Transfer("~/Errors/Unauthorized.aspx");
            }

            if (!Page.IsPostBack)
            {
                this.BindData();
            }   
        }

        protected void EditOrderStatus(object sender, EventArgs e)
        {
            var statusType = int.Parse(this.StatusType.SelectedValue);
            var paymentStatusType = int.Parse(this.PaymentStatusType.SelectedValue);

            this.EdittingOrderStatus?.Invoke(this, new EditOrderStatusEventArgs(this.Model.Order, statusType, paymentStatusType));
            this.Response.Redirect("~/administration/orderManagement");
        }

        private void BindData()
        {
            this.Products.DataSource = this.Model.Order.Products.ToList();
            this.Products.DataBind();

            this.StatusType.SelectedValue = ((int)this.Model.Order.OrderStatusType).ToString();
            this.StatusType.DataBind();

            this.PaymentStatusType.SelectedValue = ((int)this.Model.Order.OrderPaymentStatusType).ToString();
            this.PaymentStatusType.DataBind();

            this.Total.Text = this.Model.Order.Total.ToString();
        }
    }
}