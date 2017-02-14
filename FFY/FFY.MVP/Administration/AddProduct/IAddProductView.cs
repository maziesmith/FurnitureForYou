using System;
using WebFormsMvp;

namespace FFY.MVP.Administration.AddProduct
{
    public interface IAddProductView : IView<AddProductViewModel>
    {
        event EventHandler Initial;

        event EventHandler<AddProductEventArgs> AddingProduct;
    }
}