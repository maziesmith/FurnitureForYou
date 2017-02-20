using FFY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.Services.Contracts
{
    public interface IOrdersService
    {
        void AddOrder(Order product);

        IEnumerable<Order> GetOrders();

        void ChangeOrderStatus(Order order, int statusType, int paymentStatusType);

        Order GetOrderById(int id);

        IEnumerable<Order> GetOrdersByStatusTypeAndSender(int statusType, string search);

    }
}
