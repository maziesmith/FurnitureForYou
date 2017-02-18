using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.ContactManagement.ContactDetailed
{
    public interface IContactDetailedView : IView<ContactDetailedViewModel>
    {
        event EventHandler<GetContactByIdEventArgs> Initial;

        event EventHandler<EditContactStatusEventArgs> EdittingContact;
    }
}
