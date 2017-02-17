using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Furniture.FurnitureDetailed
{
    public interface IFurnitureDetailedView : IView<FurnitureDetailedViewModel>
    {
        event EventHandler<FurnitureDetailedEventArgs> GettingProductById;
    }
}
