using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Users.Cart
{
    public class RemoveFromCartArgs : EventArgs
    {
        public RemoveFromCartArgs(int productId, string cartId)
        {
            this.CartId = cartId;
            this.ProductId = productId;
            

        }
        public int ProductId { get; set; }

        public string CartId { get; set; }
    }
}
