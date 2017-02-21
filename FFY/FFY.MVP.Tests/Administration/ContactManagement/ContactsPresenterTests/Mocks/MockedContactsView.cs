using FFY.MVP.Administration.ContactManagement.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Tests.Administration.ContactManagement.ContactsPresenterTests.Mocks
{
    internal class MockedContactsView : IContactsView
    {
        private IDictionary<string, object> subscribedMethodNames = new Dictionary<string, object>();

        private event EventHandler<FilterEventArgs> filterContacts;
        private event EventHandler listingContacts;

        public event EventHandler Load;

        public event EventHandler<FilterEventArgs> FilterContacts
        {
            add
            {
                this.subscribedMethodNames.Add(value.Method.Name, value.Target);
                this.filterContacts += value;
            }
            remove
            {
                this.subscribedMethodNames.Remove(value.Method.Name);
                this.filterContacts -= value;
            }
        }

        public event EventHandler ListingContacts
        {
            add
            {
                this.subscribedMethodNames.Add(value.Method.Name, value.Target);
                this.listingContacts += value;
            }
            remove
            {
                this.subscribedMethodNames.Remove(value.Method.Name);
                this.listingContacts -= value;
            }
        }

        public ContactsViewModel Model { get; set; }

        public bool ThrowExceptionIfNoPresenterBound { get; set; }

        public bool IsSubscribedMethod(string methodName)
        {
            return this.subscribedMethodNames.ContainsKey(methodName);
        }
    }
}
