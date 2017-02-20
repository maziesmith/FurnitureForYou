using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Administration.UserManagement.UserDetailed
{
    public interface IUserDetailedView : IView<UserDetailedViewModel>
    {
        event EventHandler<GetUserByIdEventArgs> Initial;

        event EventHandler<EditUserRoleEventArgs> EdittingUserRole;
    }
}
