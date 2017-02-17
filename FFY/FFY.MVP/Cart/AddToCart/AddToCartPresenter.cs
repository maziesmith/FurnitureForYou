using FFY.Order.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.ShoppingCart.AddToCart
{
    public class AddToCartPresenter : Presenter<IAddToCartView>
    {
        private readonly IShoppingCart cart;

        public AddToCartPresenter(IAddToCartView view, IShoppingCart cart) : base(view)
        {
            if (cart == null)
            {
                throw new ArgumentNullException("cart cannot be null");
            }

            this.cart = cart;

            this.View.AddingToCart += OnAddingToCart;
        }

        private void OnAddingToCart(object sender, AddToCartEventArgs e)
        {
            this.cart.Add(e.Quantity, e.ProductId);
        }
    }
}
