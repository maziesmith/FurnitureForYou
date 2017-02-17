using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Contacts.ContactSender
{
    public interface IContactView : IView<ContactViewModel>
    {
        event EventHandler<ContactEventArgs> SendingContact;
    }
}
