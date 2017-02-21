using FFY.MVP.Administration.ProductManagement.EditProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FFY.MVP.Administration.ProductManagement.Utilities;

namespace FFY.MVP.Tests.Administration.ProductManagement.EditProductPresenterTests.Mocks
{
    internal class MockedEditProductView : IEditProductView
    {
        private IDictionary<string, object> subscribedMethodNames = new Dictionary<string, object>();

        private event EventHandler<GetProductEventArgs> initial;
        private event EventHandler<EditProductEventArgs> edittingProduct;
        private event EventHandler<UploadImageEventArgs> uploadingImage;

        public event EventHandler Load;

        public event EventHandler<GetProductEventArgs> Initial
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

        public event EventHandler<EditProductEventArgs> EdittingProduct
        {
            add
            {
                this.subscribedMethodNames.Add(value.Method.Name, value.Target);
                this.edittingProduct += value;
            }
            remove
            {
                this.subscribedMethodNames.Remove(value.Method.Name);
                this.edittingProduct -= value;
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

        public EditProductViewModel Model { get; set; }

        public bool ThrowExceptionIfNoPresenterBound { get; }

        public bool IsSubscribedMethod(string methodName)
        {
            return this.subscribedMethodNames.ContainsKey(methodName);
        }
    }
}
