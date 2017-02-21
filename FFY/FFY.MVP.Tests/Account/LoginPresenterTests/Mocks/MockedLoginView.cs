using FFY.MVP.Account.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Tests.Account.LoginPresenterTests.Mocks
{
    public class MockedLoginView : ILoginView
    {
        private IDictionary<string, object> subscribedMethodNames = new Dictionary<string, object>();

        private event EventHandler<LoginEventArgs> logging;

        public event EventHandler Load;

        public event EventHandler<LoginEventArgs> Logging
        {
            add
            {
                this.subscribedMethodNames.Add(value.Method.Name, value.Target);
                this.logging += value;
            }
            remove
            {
                this.subscribedMethodNames.Remove(value.Method.Name);
                this.logging -= value;
            }
        }

        public LoginViewModel Model { get; set; }

        public bool ThrowExceptionIfNoPresenterBound { get; }

        public bool IsSubscribedMethod(string methodName)
        {
            return this.subscribedMethodNames.ContainsKey(methodName);
        }
    }
}
