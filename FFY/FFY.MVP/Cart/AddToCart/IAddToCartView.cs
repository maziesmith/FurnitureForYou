using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Cart.AddToCart
{
    public interface IAddToCartView : IView<AddToCartViewModel>
    {
        event EventHandler<AddToCartEventArgs> AddingToCart;
    }
}
