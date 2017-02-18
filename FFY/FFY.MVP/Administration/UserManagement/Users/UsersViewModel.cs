using FFY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Administration.UserManagement.Users
{
    public class UsersViewModel
    {
        public IEnumerable<User> Users { get; set; }
    }
}
