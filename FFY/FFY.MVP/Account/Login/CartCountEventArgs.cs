using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Account.Login
{
    public class CartCountEventArgs
    {
        public CartCountEventArgs(string cartId)
        {
            if (string.IsNullOrEmpty(cartId))
            {
                throw new ArgumentNullException("Cart Id cannot be null or empty.");
            }

            this.CartId = cartId;
        }

        public string CartId { get; set; }
    }
}
