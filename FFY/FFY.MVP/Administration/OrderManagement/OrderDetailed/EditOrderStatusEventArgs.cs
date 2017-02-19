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
        public EditOrderStatusEventArgs(Order order, int statusType, int paymentStatusType)
        {
            this.Order = order;
            this.StatusType = statusType;
            this.PaymentStatusType = paymentStatusType;
        }

        public Order Order { get; set; }

        public int StatusType { get; set; }

        public int PaymentStatusType { get; set; }

    }
}
