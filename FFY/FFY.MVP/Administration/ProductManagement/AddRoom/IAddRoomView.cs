using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Administration.ProductManagement.AddRoom
{
    public interface IAddRoomView : IView<AddRoomViewModel>
    {
        event EventHandler<AddRoomEventArgs> AddingRoom;
    }
}
