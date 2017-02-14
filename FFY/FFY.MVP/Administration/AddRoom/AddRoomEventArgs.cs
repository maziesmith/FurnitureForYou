using FFY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Administration.AddRoom
{
    public class AddRoomEventArgs : EventArgs 
    {
        public AddRoomEventArgs(Room room)
        {
            if(room == null)
            {
                throw new ArgumentNullException("Room cannot be null");
            }

            this.Room = room;
        }

        public Room Room { get; set; }
    }
}
