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
        public SignInEventArgs(HttpContext context, string username, string firstName, string lastName, string email, string userRole)
        {
            this.Context = context;
            this.Username = username;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.UserRole = userRole;
        }

        public HttpContext Context { get; private set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string UserRole { get; set; }

        public string Password { get; set; }
    }
}
