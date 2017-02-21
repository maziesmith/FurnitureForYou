using FFY.MVP.Administration.ProductManagement.AddCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FFY.MVP.Administration.ProductManagement.Utilities;

namespace FFY.MVP.Tests.Administration.ProductManagement.AddCategoryPresenterTests.Mocks
{
    internal class MockedAddCategoryView : IAddCategoryView
    {
        private IDictionary<string, object> subscribedMethodNames = new Dictionary<string, object>();

        private event EventHandler<AddCategoryEventArgs> addingCategory;
        private event EventHandler<UploadImageEventArgs> uploadingImage;

        public event EventHandler Load;

        public event EventHandler<AddCategoryEventArgs> AddingCategory
        {
            add
            {
                this.subscribedMethodNames.Add(value.Method.Name, value.Target);
                this.addingCategory += value;
            }
            remove
            {
                this.subscribedMethodNames.Remove(value.Method.Name);
                this.addingCategory -= value;
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
        public AddCategoryViewModel Model { get; set; }

        public bool ThrowExceptionIfNoPresenterBound { get; }

        public bool IsSubscribedMethod(string methodName)
        {
            return this.subscribedMethodNames.ContainsKey(methodName);
        }
    }
}
