using FFY.MVP.Users.CheckOut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Tests.Users.CheckOutPresenterTests.Mocks
{
    internal class MockedCheckOutView : ICheckOutView
    {
        private IDictionary<string, object> subscribedMethodNames = new Dictionary<string, object>();

        private event EventHandler<CartClearEventArgs> cartClearing;
        private event EventHandler<CheckOutEventArgs> checkingOut;

        public event EventHandler Load;

        public event EventHandler<CartClearEventArgs> CartClearing
        {
            add
            {
                this.subscribedMethodNames.Add(value.Method.Name, value.Target);
                this.cartClearing += value;
            }
            remove
            {
                this.subscribedMethodNames.Remove(value.Method.Name);
                this.cartClearing -= value;
            }
        }

        public event EventHandler<CheckOutEventArgs> CheckingOut
        {
            add
            {
                this.subscribedMethodNames.Add(value.Method.Name, value.Target);
                this.checkingOut += value;
            }
            remove
            {
                this.subscribedMethodNames.Remove(value.Method.Name);
                this.checkingOut -= value;
            }
        }

        public CheckOutViewModel Model { get; set; }

        public bool ThrowExceptionIfNoPresenterBound { get; }

        public bool IsSubscribedMethod(string methodName)
        {
            return this.subscribedMethodNames.ContainsKey(methodName);
        }
    }
}
