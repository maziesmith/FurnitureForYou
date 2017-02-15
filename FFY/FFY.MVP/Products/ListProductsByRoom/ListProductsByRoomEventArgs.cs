using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Products.ListProductsByRoom
{
    public class ListProductsByRoomEventArgs : EventArgs
    {
        public ListProductsByRoomEventArgs(string roomNameFiltered)
        {
            this.RoomName = roomNameFiltered;
        }

        public string RoomName { get; set; }
    }
}
