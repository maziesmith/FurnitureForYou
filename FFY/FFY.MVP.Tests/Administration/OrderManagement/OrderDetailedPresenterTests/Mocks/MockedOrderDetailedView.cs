using FFY.MVP.OrderManagement.OrderDetailed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Tests.Administration.OrderManagement.OrderDetailedPresenterTests.Mocks
{
    internal class MockedOrderDetailedView : IOrderDetailedView
    {
        private IDictionary<string, object> subscribedMethodNames = new Dictionary<string, object>();

        private event EventHandler<EditOrderStatusEventArgs> edittingOrderStatus;
        private event EventHandler<GetOrderByIdEventArgs> initial;

        public event EventHandler Load;

        public event EventHandler<EditOrderStatusEventArgs> EdittingOrderStatus
        {
            add
            {
                this.subscribedMethodNames.Add(value.Method.Name, value.Target);
                this.edittingOrderStatus += value;
            }
            remove
            {
                this.subscribedMethodNames.Remove(value.Method.Name);
                this.edittingOrderStatus -= value;
            }
        }

        public event EventHandler<GetOrderByIdEventArgs> Initial
        {
            add
            {
                this.subscribedMethodNames.Add(value.Method.Name, value.Target);
                this.initial += value;
            }
            remove
            {
                this.subscribedMethodNames.Remove(value.Method.Name);
                this.initial -= value;
            }
        }

        public OrderDetailedViewModel Model { get; set; }

        public bool ThrowExceptionIfNoPresenterBound { get; }

        public bool IsSubscribedMethod(string methodName)
        {
            return this.subscribedMethodNames.ContainsKey(methodName);
        }
    }
}
