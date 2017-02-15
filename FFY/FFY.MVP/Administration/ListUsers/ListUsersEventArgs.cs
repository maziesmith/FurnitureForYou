using FFY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Administration.ListUsers
{
    public class ListUsersEventArgs : EventArgs
    {
        public ListUsersEventArgs(IEnumerable<User> users)
        {
            if(users == null)
            {
                throw new ArgumentNullException("Users cannot be null");
            }

            this.Users = users;
        }

        public IEnumerable<User> Users { get; set; }
    }
}
