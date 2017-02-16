using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Products.ListAllProducts
{
    public class ListAllProductsEventArgs : EventArgs
    {
        public ListAllProductsEventArgs(string roomNameFiltered)
        {
            this.RoomName = roomNameFiltered;
        }

        public string RoomName { get; set; }
    }
}
