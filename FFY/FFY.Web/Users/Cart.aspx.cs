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

        protected void Page_Load(object sender, EventArgs e)
        {
            var id = this.Page.User.Identity.GetUserId();
            this.Initial?.Invoke(this, new CartEventArgs(id));

            this.Products.DataSource = this.Model.ShoppingCart.CartProducts.ToList();
            this.Products.DataBind();

            this.Total.Text = this.Model.ShoppingCart.Total.ToString();
        }
    }
}