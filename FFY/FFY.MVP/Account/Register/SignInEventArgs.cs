using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FFY.Models;
using System.Web;

namespace FFY.MVP.Account.Register
{
    public class SignInEventArgs : EventArgs
    {
        public SignInEventArgs(HttpContext context, User user)
        {
            this.Context = context;
            this.User = user;
        }

        public HttpContext Context { get; private set; }

        public User User { get; private set; }
    }
}
