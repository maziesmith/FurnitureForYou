using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Users.CheckOut
{
    public interface ICheckOutView : IView<CheckOutViewModel>
    {
        event EventHandler<CartClearEventArgs> CartClearing;

        event EventHandler<CheckOutEventArgs> CheckingOut;
    }
}
