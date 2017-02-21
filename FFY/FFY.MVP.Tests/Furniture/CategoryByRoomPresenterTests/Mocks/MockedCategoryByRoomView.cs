using FFY.MVP.Furniture.CategoryByRoom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Tests.Furniture.CategoryByRoomPresenterTests.Mocks
{
    internal class MockedCategoryByRoomView : ICategoryByRoomView
    {
        private IDictionary<string, object> subscribedMethodNames = new Dictionary<string, object>();

        private event EventHandler<CategoryByRoomEventArgs> listingCategoriesByRoom;

        public event EventHandler Load;

        public event EventHandler<CategoryByRoomEventArgs> ListingCategoriesByRoom
        {
            add
            {
                this.subscribedMethodNames.Add(value.Method.Name, value.Target);
                this.listingCategoriesByRoom += value;
            }
            remove
            {
                this.subscribedMethodNames.Remove(value.Method.Name);
                this.listingCategoriesByRoom -= value;
            }
        }

        public CategoryByRoomViewModel Model { get; set; }

        public bool ThrowExceptionIfNoPresenterBound { get; }

        public bool IsSubscribedMethod(string methodName)
        {
            return this.subscribedMethodNames.ContainsKey(methodName);
        }
    }
}
