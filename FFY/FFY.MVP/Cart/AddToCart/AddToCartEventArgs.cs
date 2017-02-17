using System;

namespace FFY.MVP.Cart.AddToCart
{
    public class AddToCartEventArgs : EventArgs
    {
        public AddToCartEventArgs(int quantity, int productId)
        {
            this.Quantity = quantity;
            this.ProductId = productId;
        }
        public int Quantity { get; set; }

        public int ProductId { get; set; }

    }
}