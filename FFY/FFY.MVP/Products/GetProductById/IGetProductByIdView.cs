using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Products.GetProductById
{
    public interface IGetProductByIdView : IView<GetProductByIdViewModel>
    {
        event EventHandler<GetProductByIdEventArgs> GettingProductById;
    }
}
