using FFY.MVP.ContactManagement.ContactDetailed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.Tests.MVP.Administration.ContactManagement.ContactDetailedPresenterTests.Mocks
{
    internal class MockedContactDetailedView : IContactDetailedView
    {
        private IDictionary<string, object> subscribedMethodNames = new Dictionary<string, object>();

        private event EventHandler<EditContactStatusEventArgs> edittingContactStatus;
        private event EventHandler<GetContactByIdEventArgs> initial;

        public event EventHandler Load;

        public event EventHandler<EditContactStatusEventArgs> EdittingContactStatus
        {
            add
            {
                this.subscribedMethodNames.Add(value.Method.Name, value.Target);
                this.edittingContactStatus += value;
            }
            remove
            {
                this.subscribedMethodNames.Remove(value.Method.Name);
                this.edittingContactStatus -= value;
            }
        }

        public event EventHandler<GetContactByIdEventArgs> Initial
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
        public ContactDetailedViewModel Model { get; set; }

        public bool ThrowExceptionIfNoPresenterBound { get; }

        public bool IsSubscribedMethod(string methodName)
        {
            return this.subscribedMethodNames.ContainsKey(methodName);
        }
    }
}
