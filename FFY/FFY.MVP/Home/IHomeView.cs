using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Home
{
    public interface IHomeView : IView<HomeViewModel>
    {
        event EventHandler<HomeEventArgs> ListingDiscountProducts;

        event EventHandler<HomeEventArgs> ListingLatestProducts;
    }
}
