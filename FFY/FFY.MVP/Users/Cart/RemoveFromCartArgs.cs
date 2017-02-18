using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Users.Cart
{
    public class RemoveFromCartArgs
    {
        public RemoveFromCartArgs(int productId, string cartId)
        {
            if(string.IsNullOrEmpty(cartId))
            {
                throw new ArgumentNullException("Cart Id cannot be null.");
            }

            this.CartId = cartId;
            this.ProductId = productId;
            

        }
        public int ProductId { get; set; }

        public string CartId { get; set; }
    }
}
