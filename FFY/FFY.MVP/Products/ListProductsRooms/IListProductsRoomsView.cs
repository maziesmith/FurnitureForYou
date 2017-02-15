using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Products.ListProductsRooms
{
    public interface IListProductsRoomsView : IView<ListProductsRoomsViewModel>
    {
        event EventHandler ListingProductsRooms;
    }
}
