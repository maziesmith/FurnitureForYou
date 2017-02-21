using FFY.MVP.Administration.ProductManagement.AddProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FFY.MVP.Administration.ProductManagement.Utilities;

namespace FFY.MVP.Tests.Administration.ProductManagement.AddProductPresenterTests.Mocks
{
    internal class MockedAddProductView : IAddProductView
    {
        private IDictionary<string, object> subscribedMethodNames = new Dictionary<string, object>();

        private event EventHandler initial;
        private event EventHandler<AddProductEventArgs> addingProduct;
        private event EventHandler<UploadImageEventArgs> uploadingImage;

        public event EventHandler Load;

        public event EventHandler Initial
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

        public event EventHandler<AddProductEventArgs> AddingProduct
        {
            add
            {
                this.subscribedMethodNames.Add(value.Method.Name, value.Target);
                this.addingProduct += value;
            }
            remove
            {
                this.subscribedMethodNames.Remove(value.Method.Name);
                this.addingProduct -= value;
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


        public AddProductViewModel Model { get; set; }

        public bool ThrowExceptionIfNoPresenterBound { get; }

        public bool IsSubscribedMethod(string methodName)
        {
            return this.subscribedMethodNames.ContainsKey(methodName);
        }
    }
}
