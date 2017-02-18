using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Users.Cart
{
    public class CartEventArgs : EventArgs
    {
        public CartEventArgs(string cartId)
        {
            this.CartId = cartId;
        }

        public string CartId { get; set; }
    }
}
