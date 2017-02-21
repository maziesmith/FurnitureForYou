using FFY.MVP.Contacts.ContactSender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Tests.Contacts.ContactsPresenterTests.Mocks
{
    internal class MockedContactView : IContactView
    {
        private IDictionary<string, object> subscribedMethodNames = new Dictionary<string, object>();

        private event EventHandler<ContactEventArgs> sendingContact;

        public event EventHandler Load;
        public event EventHandler<ContactEventArgs> SendingContact
        {
            add
            {
                this.subscribedMethodNames.Add(value.Method.Name, value.Target);
                this.sendingContact += value;
            }
            remove
            {
                this.subscribedMethodNames.Remove(value.Method.Name);
                this.sendingContact -= value;
            }
        }

        public ContactViewModel Model { get; set; }

        public bool ThrowExceptionIfNoPresenterBound { get; }

        public bool IsSubscribedMethod(string methodName)
        {
            return this.subscribedMethodNames.ContainsKey(methodName);
        }
    }
}
