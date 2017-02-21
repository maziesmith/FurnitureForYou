using FFY.MVP.Furniture.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Tests.Furniture.ProductsPresenterTests.Mocks
{
    internal class MockedProductsView : IProductsView
    {
        private IDictionary<string, object> subscribedMethodNames = new Dictionary<string, object>();

        private event EventHandler<QueryEventArgs> buildingQuery;
        private event EventHandler<ProductsEventArgs> listingProducts;

        public event EventHandler Load;

        public event EventHandler<QueryEventArgs> BuildingQuery
        {
            add
            {
                this.subscribedMethodNames.Add(value.Method.Name, value.Target);
                this.buildingQuery += value;
            }
            remove
            {
                this.subscribedMethodNames.Remove(value.Method.Name);
                this.buildingQuery -= value;
            }
        }

        public event EventHandler<ProductsEventArgs> ListingProducts
        {
            add
            {
                this.subscribedMethodNames.Add(value.Method.Name, value.Target);
                this.listingProducts += value;
            }
            remove
            {
                this.subscribedMethodNames.Remove(value.Method.Name);
                this.listingProducts -= value;
            }
        }

        public ProductsViewModel Model { get; set; }

        public bool ThrowExceptionIfNoPresenterBound { get; }

        public bool IsSubscribedMethod(string methodName)
        {
            return this.subscribedMethodNames.ContainsKey(methodName);
        }
    }
}
