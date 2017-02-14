using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Account.Profile
{
    public interface IProfileView : IView<ProfileViewModel>
    {
        event EventHandler<ProfileByIdEventArgs> GettingUserById;
    }
}
