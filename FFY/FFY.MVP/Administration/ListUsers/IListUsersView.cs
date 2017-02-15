using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Administration.ListUsers
{
    public interface IListUsersView : IView<ListUsersViewModel>
    {
        event EventHandler ListingUsers;
    }
}
