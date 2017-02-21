using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Furniture.CategoryByRoom
{
    public interface ICategoryByRoomView : IView<CategoryByRoomViewModel>
    {
        event EventHandler<CategoryByRoomEventArgs> ListingCategoriesByRoom;
    }
}
