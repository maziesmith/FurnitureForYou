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
        public RegisterEventArgs(HttpContext context, string username, string firstName, string lastName, string email, string userRole, string password)
        {
            this.Context = context;
            this.Username = username;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.UserRole = userRole;
            this.Password = password;
        }

        public HttpContext Context { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string UserRole { get; set; }

        public string Password { get; set; }

    }
}
