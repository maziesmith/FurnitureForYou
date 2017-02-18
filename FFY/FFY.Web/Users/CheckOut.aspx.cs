using FFY.Models;
using FFY.MVP.Users.CheckOut;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace FFY.Web.Users
{
    [PresenterBinding(typeof(CheckOutPresenter))]
    public partial class CheckOut : MvpPage<CheckOutViewModel>, ICheckOutView
    {
        public event EventHandler<CheckOutEventArgs> CheckingOut;
        public event EventHandler<CartClearEventArgs> CartClearing;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack && Request.UrlReferrer != null)
            {
                var previousUrl = Request.UrlReferrer.AbsolutePath.ToLower();
                
                if(previousUrl != "/users/cart")
                {
                    this.Response.Redirect("~/users/cart");
                }
            }
        }

        protected void CheckOutOrder(object sender, EventArgs e)
        {
            var cartId = this.User.Identity.GetUserId();
            var street = this.Street.Text;
            var city = this.City.Text;
            var country = this.Country.Text;
            var phoneNumber = this.PhoneNumber.Text;
            var sendOn = DateTime.Now;
            var orderPaymentStatusType =
                this.PaymentTypeSelection.SelectedValue == "On Delivery" ? OrderPaymentStatusType.PaymentOnDelivery : OrderPaymentStatusType.Payed;
            var orderStatusType = OrderStatusType.Processing;

            this.CheckingOut?.Invoke(this, new CheckOutEventArgs(cartId,
                street,
                city,
                country,
                phoneNumber,
                sendOn,
                orderPaymentStatusType,
                orderStatusType));

            this.CartClearing?.Invoke(this, new CartClearEventArgs(cartId));

            this.Cache.Insert($"cart-count-{cartId}", 0);
        }
    }
}