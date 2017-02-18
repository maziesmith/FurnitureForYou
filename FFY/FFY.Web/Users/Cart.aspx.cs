using FFY.Models;
using FFY.MVP.Users.Cart;
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
    [PresenterBinding(typeof(CartPresenter))]
    public partial class Cart : MvpPage<CartViewModel>, ICartView
    {
        public event EventHandler<CartEventArgs> Initial;
        public event EventHandler<RemoveFromCartArgs> RemovingFromCart;

        protected void Page_Load(object sender, EventArgs e)
        {
            var id = this.Page.User.Identity.GetUserId();
            this.Initial?.Invoke(this, new CartEventArgs(id));

            this.Products.DataSource = this.Model.ShoppingCart.CartProducts.ToList();
            this.Products.DataBind();

            this.Total.Text = this.Model.ShoppingCart.Total.ToString();
        }

        protected void Products_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var productId = int.Parse(e.Keys[0].ToString());
            var cartId = this.User.Identity.GetUserId();
            this.RemovingFromCart?.Invoke(this, new RemoveFromCartArgs(productId, cartId));

            this.Cache.Insert($"cart-count-{cartId}", this.Model.CartCount);

            this.Products.DataSource = this.Model.ShoppingCart.CartProducts.ToList();
            this.Products.DataBind();

            this.Total.Text = this.Model.ShoppingCart.Total.ToString();
        }
    }
}