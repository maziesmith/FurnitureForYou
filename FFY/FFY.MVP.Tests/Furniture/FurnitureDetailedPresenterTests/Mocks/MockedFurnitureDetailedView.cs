using FFY.MVP.Furniture.FurnitureDetailed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Tests.Furniture.FurnitureDetailedPresenterTests.Mocks
{
    internal class MockedFurnitureDetailedView : IFurnitureDetailedView
    {
        private IDictionary<string, object> subscribedMethodNames = new Dictionary<string, object>();

        private event EventHandler<AddToShoppingCartEventArgs> addingToShoppingCart;
        private event EventHandler<FurnitureDetailedEventArgs> gettingProductById;

        public event EventHandler Load;

        public event EventHandler<AddToShoppingCartEventArgs> AddingToShoppingCart
        {
            add
            {
                this.subscribedMethodNames.Add(value.Method.Name, value.Target);
                this.addingToShoppingCart += value;
            }
            remove
            {
                this.subscribedMethodNames.Remove(value.Method.Name);
                this.addingToShoppingCart -= value;
            }
        }

        public event EventHandler<FurnitureDetailedEventArgs> GettingProductById
        {
            add
            {
                this.subscribedMethodNames.Add(value.Method.Name, value.Target);
                this.gettingProductById += value;
            }
            remove
            {
                this.subscribedMethodNames.Remove(value.Method.Name);
                this.gettingProductById -= value;
            }
        }

        public FurnitureDetailedViewModel Model { get; set; }

        public bool ThrowExceptionIfNoPresenterBound { get; }

        public bool IsSubscribedMethod(string methodName)
        {
            return this.subscribedMethodNames.ContainsKey(methodName);
        }
    }
}
