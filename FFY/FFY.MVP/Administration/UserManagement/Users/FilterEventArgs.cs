using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Administration.UserManagement.Users
{
    public class FilterEventArgs
    {
        public FilterEventArgs(int roleType, string search)
        {
            this.RoleType = roleType;
            this.Search = search;
        }

        public string Search { get; set; }

        public int RoleType { get; set; }
    }
}
