using FFY.MVP.Administration.UserManagement.UserDetailed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.Tests.MVP.Administration.UserManagement.UserDetailedPresenterTests.Mocks
{
    internal class MockedUserDetailedView : IUserDetailedView
    {
        private IDictionary<string, object> subscribedMethodNames = new Dictionary<string, object>();

        private event EventHandler<EditUserRoleEventArgs> edittingUserRole;
        private event EventHandler<GetUserByIdEventArgs> initial;

        public event EventHandler Load;

        public event EventHandler<EditUserRoleEventArgs> EdittingUserRole
        {
            add
            {
                this.subscribedMethodNames.Add(value.Method.Name, value.Target);
                this.edittingUserRole += value;
            }
            remove
            {
                this.subscribedMethodNames.Remove(value.Method.Name);
                this.edittingUserRole -= value;
            }
        }

        public event EventHandler<GetUserByIdEventArgs> Initial
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

        public UserDetailedViewModel Model { get; set; }

        public bool ThrowExceptionIfNoPresenterBound { get; }

        public bool IsSubscribedMethod(string methodName)
        {
            return this.subscribedMethodNames.ContainsKey(methodName);
        }
    }
}
