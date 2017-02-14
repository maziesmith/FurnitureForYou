using System;
using WebFormsMvp;

namespace FFY.MVP.Administration.AddCategory
{
    public interface IAddCategoryView : IView<AddCategoryViewModel>
    {
        event EventHandler<AddCategoryEventArgs> AddingCategory;
    }
}