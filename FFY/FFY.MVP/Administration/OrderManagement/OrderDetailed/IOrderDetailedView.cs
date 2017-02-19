using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.OrderManagement.OrderDetailed
{
    public interface IOrderDetailedView : IView<OrderDetailedViewModel>
    {
        event EventHandler<GetOrderByIdEventArgs> Initial;

        event EventHandler<EditOrderStatusEventArgs> EdittingOrderStatus;
    }
}
