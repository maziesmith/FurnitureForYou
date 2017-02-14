using FFY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FFY.MVP.Account.Register
{
    public class RegisterEventArgs : EventArgs
    {
        public RegisterEventArgs(HttpContext context, User user, string password)
        {
            this.Context = context;
            this.User = user;
            this.Password = password;
        }

        public HttpContext Context { get; set; }

        public User User { get; private set; }

        public string Password { get; set; }
    }
}
