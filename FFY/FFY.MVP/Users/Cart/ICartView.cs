using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Users.Cart
{
    public interface ICartView : IView<CartViewModel>
    {
        event EventHandler<CartEventArgs> Initial;
    }
}
