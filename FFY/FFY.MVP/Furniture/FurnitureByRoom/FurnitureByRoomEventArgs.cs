using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Furniture.FurnitureByRoom
{
    public class FurnitureByRoomEventArgs : EventArgs
    {
        public FurnitureByRoomEventArgs(string roomNameFiltered)
        {
            this.RoomName = roomNameFiltered;
        }

        public string RoomName { get; set; }
    }
}
