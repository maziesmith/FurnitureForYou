using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Furniture.CategoryByRoom
{
    public class CategoryByRoomEventArgs : EventArgs
    {
        public CategoryByRoomEventArgs(string roomNameFiltered)
        {
            this.RoomName = roomNameFiltered;
        }

        public string RoomName { get; set; }
    }
}
