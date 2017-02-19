using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Administration.OrderManagement.Orders
{
    public interface IOrdersView : IView<OrdersViewModel>
    {
        event EventHandler ListingOrders;
    }
}
