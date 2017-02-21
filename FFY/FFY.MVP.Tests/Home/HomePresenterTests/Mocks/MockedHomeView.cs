using FFY.MVP.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Tests.Home.HomePresenterTests.Mocks
{
    internal class MockedHomeView : IHomeView
    {
        private IDictionary<string, object> subscribedMethodNames = new Dictionary<string, object>();

        private event EventHandler<HomeEventArgs> listingDiscountProducts;
        private event EventHandler<HomeEventArgs> listingLatestProducts;

        public event EventHandler Load;

        public event EventHandler<HomeEventArgs> ListingDiscountProducts
        {
            add
            {
                this.subscribedMethodNames.Add(value.Method.Name, value.Target);
                this.listingDiscountProducts += value;
            }
            remove
            {
                this.subscribedMethodNames.Remove(value.Method.Name);
                this.listingDiscountProducts -= value;
            }
        }

        public event EventHandler<HomeEventArgs> ListingLatestProducts
        {
            add
            {
                this.subscribedMethodNames.Add(value.Method.Name, value.Target);
                this.listingLatestProducts += value;
            }
            remove
            {
                this.subscribedMethodNames.Remove(value.Method.Name);
                this.ListingLatestProducts -= value;
            }
        }

        public HomeViewModel Model { get; set; }

        public bool ThrowExceptionIfNoPresenterBound { get; }

        public bool IsSubscribedMethod(string methodName)
        {
            return this.subscribedMethodNames.ContainsKey(methodName);
        }
    }
}
