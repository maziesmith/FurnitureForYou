using FFY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Administration.OrderManagement.Orders
{
    public class OrdersViewModel
    {
        public IEnumerable<Order> Orders { get; set; }

    }
}
