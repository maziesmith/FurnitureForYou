using FFY.MVP.Users.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Tests.Users.Mocks.CartPresenterTests
{
    internal class MockedCartView : ICartView
    {
        private IDictionary<string, object> subscribedMethodNames = new Dictionary<string, object>();

        private event EventHandler<CartEventArgs> initial;
        private event EventHandler<RemoveFromCartArgs> removingFromCart;

        public event EventHandler Load;

        public event EventHandler<CartEventArgs> Initial
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

        public event EventHandler<RemoveFromCartArgs> RemovingFromCart
        {
            add
            {
                this.subscribedMethodNames.Add(value.Method.Name, value.Target);
                this.removingFromCart += value;
            }
            remove
            {
                this.subscribedMethodNames.Remove(value.Method.Name);
                this.removingFromCart -= value;
            }
        }

        public CartViewModel Model { get; set; }

        public bool ThrowExceptionIfNoPresenterBound { get; }

        public bool IsSubscribedMethod(string methodName)
        {
            return this.subscribedMethodNames.ContainsKey(methodName);
        }
    }
}
