using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Products.ListProductsByRoom
{
    public interface IListProductsByRoomView : IView<ListProductsByRoomViewModel>
    {
        event EventHandler<ListProductsByRoomEventArgs> ListingProductsByRoom;
    }
}
