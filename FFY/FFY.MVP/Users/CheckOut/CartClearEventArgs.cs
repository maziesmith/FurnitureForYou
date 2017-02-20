using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Users.CheckOut
{
    public class CartClearEventArgs : EventArgs
    {
        public CartClearEventArgs(string cartId)
        {
            this.CartId = cartId;
        }

        public string CartId { get; set; }
    }
}
