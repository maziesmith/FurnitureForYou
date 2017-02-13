using System;
using System.Web;

namespace FFY.MVP.Account.Login
{
    public class LoginEventArgs : EventArgs
    {
        public LoginEventArgs(HttpContext context,
            string userName, string password,
            bool rememberMe,
            bool shouldLockOut)
        {
            this.Context = context;
            this.UserName = userName;
            this.Password = password;
            this.RememberMe = rememberMe;
            this.ShouldLockOut = shouldLockOut;
        }

        public HttpContext Context { get; set; }

        public string UserName { get; private set; }

        public string Password { get; private set; }

        public bool RememberMe { get; private set; }

        public bool ShouldLockOut { get; private set; }
    }
}
