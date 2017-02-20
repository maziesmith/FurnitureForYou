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
            this.Quantity = quantity;
            this.CartId = cartId;
        }

        public int Quantity { get; set; }

        public string CartId { get; set; }

    }
}
