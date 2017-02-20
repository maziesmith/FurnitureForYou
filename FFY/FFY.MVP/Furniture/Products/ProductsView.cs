using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Furniture.Products
{
    public interface IProductsView : IView<ProductsViewModel>
    {
        event EventHandler<ProductsEventArgs> ListingProducts;
    }
}
