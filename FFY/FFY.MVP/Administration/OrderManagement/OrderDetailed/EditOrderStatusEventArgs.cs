using FFY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.OrderManagement.OrderDetailed
{
    public class EditOrderStatusEventArgs : EventArgs
    {
        public EditOrderStatusEventArgs(Order order, int statusType)
        {
            this.Order = order;
            this.StatusType = statusType;
        }

        public Order Order { get; set; }

        public int StatusType { get; set; }
    }
}
