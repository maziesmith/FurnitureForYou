using FFY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FFY.MVP.Administration.UserManagement.UserDetailed
{
    public class EditUserRoleEventArgs : EventArgs
    {
        public EditUserRoleEventArgs(HttpContext context, User user, string roleType)
        {
            if(context == null)
            {
                throw new ArgumentNullException("Http Context cannot be null.");
            }

            if(user == null)
            {
                throw new ArgumentNullException("User cannot be null.");
            }

            this.Context = context;
            this.User = user;
            this.RoleType = roleType;
        }

        public HttpContext Context { get; set; }

        public string RoleType { get; set; }

        public User User { get; set; }

    }
}
