using FFY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Administration.ProductManagement.AddRoom
{
    public class AddRoomEventArgs : EventArgs 
    {
        public AddRoomEventArgs(string roomName)
        {
            this.RoomName = roomName;
        }

        public string RoomName { get; set; }
    }
}
