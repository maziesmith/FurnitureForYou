using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Furniture.FurnitureDetailed
{
    public class AddToShoppingCartEventArgs : EventArgs
    {
        public AddToShoppingCartEventArgs(int quantity, string cartId)
        {
            if(quantity < 0)
            {
                throw new ArgumentOutOfRangeException("Quantity of product cannot be negative.");
            }

            if(string.IsNullOrEmpty(cartId))
            {
                throw new ArgumentNullException("Cart Id cannot be null.");
            }

            this.Quantity = quantity;
            this.CartId = cartId;
        }

        public int Quantity { get; set; }

        public string CartId { get; set; }

    }
}
