using FFY.MVP.Administration.UserManagement.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.Tests.MVP.Administration.UserManagement.UsersPresenterTests.Mocks
{
    internal class MockedUsersView : IUsersView
    {
        private IDictionary<string, object> subscribedMethodNames = new Dictionary<string, object>();

        private event EventHandler<FilterEventArgs> filterUsers;
        private event EventHandler listingUsers;

        public event EventHandler Load;

        public event EventHandler<FilterEventArgs> FilterUsers
        {
            add
            {
                this.subscribedMethodNames.Add(value.Method.Name, value.Target);
                this.filterUsers += value;
            }
            remove
            {
                this.subscribedMethodNames.Remove(value.Method.Name);
                this.filterUsers -= value;
            }
        }

        public event EventHandler ListingUsers
        {
            add
            {
                this.subscribedMethodNames.Add(value.Method.Name, value.Target);
                this.listingUsers += value;
            }
            remove
            {
                this.subscribedMethodNames.Remove(value.Method.Name);
                this.listingUsers -= value;
            }
        }

        public UsersViewModel Model { get; set; }

        public bool ThrowExceptionIfNoPresenterBound { get; set; }

        public bool IsSubscribedMethod(string methodName)
        {
            return this.subscribedMethodNames.ContainsKey(methodName);
        }
    }
}
