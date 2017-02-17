using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Furniture.FurnitureByRoom
{
    public interface IFurnitureByRoomView : IView<FurnitureByRoomViewModel>
    {
        event EventHandler<FurnitureByRoomEventArgs> ListingFurnitureByRoom;
    }
}
