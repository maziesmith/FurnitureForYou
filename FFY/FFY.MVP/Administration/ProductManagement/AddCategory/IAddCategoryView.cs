using FFY.MVP.Administration.ProductManagement.Utilities;
using System;
using WebFormsMvp;

namespace FFY.MVP.Administration.ProductManagement.AddCategory
{
    public interface IAddCategoryView : IView<AddCategoryViewModel>
    {
        event EventHandler<AddCategoryEventArgs> AddingCategory;

        event EventHandler<UploadImageEventArgs> UploadingImage;

    }
}