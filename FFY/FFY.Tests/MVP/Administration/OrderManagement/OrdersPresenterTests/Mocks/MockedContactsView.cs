using FFY.MVP.Administration.OrderManagement.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.Tests.MVP.Administration.OrderManagement.OrdersPresenterTests.Mocks
{
    internal class MockedOrdersView : IOrdersView
    {
        private IDictionary<string, object> subscribedMethodNames = new Dictionary<string, object>();

        private event EventHandler<FilterEventArgs> filterOrders;
        private event EventHandler listingOrders;

        public event EventHandler Load;

        public event EventHandler<FilterEventArgs> FilterOrders
        {
            add
            {
                this.subscribedMethodNames.Add(value.Method.Name, value.Target);
                this.filterOrders += value;
            }
            remove
            {
                this.subscribedMethodNames.Remove(value.Method.Name);
                this.filterOrders -= value;
            }
        }

        public event EventHandler ListingOrders
        {
            add
            {
                this.subscribedMethodNames.Add(value.Method.Name, value.Target);
                this.listingOrders += value;
            }
            remove
            {
                this.subscribedMethodNames.Remove(value.Method.Name);
                this.listingOrders -= value;
            }
        }

        public OrdersViewModel Model { get; set; }

        public bool ThrowExceptionIfNoPresenterBound { get; set; }

        public bool IsSubscribedMethod(string methodName)
        {
            return this.subscribedMethodNames.ContainsKey(methodName);
        }
    }
}
