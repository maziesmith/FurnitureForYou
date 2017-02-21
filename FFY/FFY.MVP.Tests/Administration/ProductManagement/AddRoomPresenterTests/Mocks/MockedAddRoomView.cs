using FFY.MVP.Administration.ProductManagement.AddRoom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FFY.MVP.Administration.ProductManagement.Utilities;

namespace FFY.MVP.Tests.Administration.ProductManagement.AddRoomPresenterTests.Mocks
{
    internal class MockedAddRoomView : IAddRoomView
    {
        private IDictionary<string, object> subscribedMethodNames = new Dictionary<string, object>();

        private event EventHandler<AddRoomEventArgs> addingRoom;
        private event EventHandler<UploadImageEventArgs> uploadingImage;

        public event EventHandler Load;

        public event EventHandler<AddRoomEventArgs> AddingRoom
        {
            add
            {
                this.subscribedMethodNames.Add(value.Method.Name, value.Target);
                this.addingRoom += value;
            }
            remove
            {
                this.subscribedMethodNames.Remove(value.Method.Name);
                this.addingRoom -= value;
            }
        }

        public event EventHandler<UploadImageEventArgs> UploadingImage
        {
            add
            {
                this.subscribedMethodNames.Add(value.Method.Name, value.Target);
                this.uploadingImage += value;
            }
            remove
            {
                this.subscribedMethodNames.Remove(value.Method.Name);
                this.uploadingImage -= value;
            }
        }

        public AddRoomViewModel Model { get; set; }

        public bool ThrowExceptionIfNoPresenterBound { get; }

        public bool IsSubscribedMethod(string methodName)
        {
            return this.subscribedMethodNames.ContainsKey(methodName);
        }
    }
}
