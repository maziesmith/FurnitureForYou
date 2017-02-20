using FFY.MVP.Account.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.Tests.MVP.Account.RegisterPresenterTests.Mocks
{
    internal class MockedRegisterView : IRegisterView
    {
        private IDictionary<string, object> subscribedMethodNames = new Dictionary<string, object>();

        private event EventHandler<RegisterEventArgs> registering;
        private event EventHandler<SignInEventArgs> signingIn;

        public event EventHandler Load;

        public event EventHandler<RegisterEventArgs> Registering
        {
            add
            {
                this.subscribedMethodNames.Add(value.Method.Name, value.Target);
                this.registering += value;
            }
            remove
            {
                this.subscribedMethodNames.Remove(value.Method.Name);
                this.registering += value;
            }
        }

        public event EventHandler<SignInEventArgs> SigningIn
        {
            add
            {
                this.subscribedMethodNames.Add(value.Method.Name, value.Target);
                this.signingIn += value;
            }
            remove
            {
                this.subscribedMethodNames.Remove(value.Method.Name);
                this.signingIn += value;
            }
        }

        public RegisterViewModel Model { get; set; }

        public bool ThrowExceptionIfNoPresenterBound { get; }

        public bool IsSubscribedMethod(string methodName)
        {
            return this.subscribedMethodNames.ContainsKey(methodName);
        }
    }
}
