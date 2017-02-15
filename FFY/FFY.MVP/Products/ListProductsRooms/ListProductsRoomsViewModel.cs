using FFY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Products.ListProductsRooms
{
    public class ListProductsRoomsViewModel
    {
        public IEnumerable<Room> Rooms { get; set; }
    }
}
