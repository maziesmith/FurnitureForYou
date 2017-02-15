using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Users.SendContact
{
    public interface ISendContactView : IView<SendContactViewModel>
    {
        event EventHandler<SendContactEventArgs> SendingContact;
    }
}
