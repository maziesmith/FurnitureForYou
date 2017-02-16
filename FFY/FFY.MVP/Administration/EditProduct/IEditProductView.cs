using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Administration.EditProduct
{
    public interface IEditProductView : IView<EditProductViewModel>
    {
        event EventHandler<GetProductEventArgs> Initial;
        event EventHandler<EditProductEventArgs> EdittingProduct;
    }
}
