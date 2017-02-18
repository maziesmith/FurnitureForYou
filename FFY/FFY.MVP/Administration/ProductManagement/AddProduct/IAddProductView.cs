using System;
using WebFormsMvp;

namespace FFY.MVP.Administration.ProductManagement.AddProduct
{
    public interface IAddProductView : IView<AddProductViewModel>
    {
        event EventHandler Initial;

        event EventHandler<AddProductEventArgs> AddingProduct;

        event EventHandler<UploadImageEventArgs> UploadingImage;
    }
}