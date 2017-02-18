using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Administration.UserManagement.Users
{
    public interface IUsersView : IView<UsersViewModel>
    {
        event EventHandler ListingUsers;
    }
}
