using FFY.MVP.Furniture.ListProductsRooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Tests.Furniture.FurnitureRoomsPresenterTests.Mocks
{
    internal class MockedFurnitureRoomsView : IFurnitureRoomsView
    {
        private IDictionary<string, object> subscribedMethodNames = new Dictionary<string, object>();

        private event EventHandler listingFurnitureRooms;

        public event EventHandler Load;

        public event EventHandler ListingFurnitureRooms
        {
            add
            {
                this.subscribedMethodNames.Add(value.Method.Name, value.Target);
                this.listingFurnitureRooms += value;
            }
            remove
            {
                this.subscribedMethodNames.Remove(value.Method.Name);
                this.listingFurnitureRooms -= value;
            }
        }

        public FurnitureRoomsViewModel Model { get; set; }

        public bool ThrowExceptionIfNoPresenterBound { get; }

        public bool IsSubscribedMethod(string methodName)
        {
            return this.subscribedMethodNames.ContainsKey(methodName);
        }
    }
}
