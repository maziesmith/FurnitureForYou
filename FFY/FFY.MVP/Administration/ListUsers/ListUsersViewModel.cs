using FFY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Administration.ListUsers
{
    public class ListUsersViewModel
    {
        public IEnumerable<User> Users { get; set; }
    }
}
