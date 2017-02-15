using FFY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Users.SendContact
{
    public class SendContactEventArgs : EventArgs
    {
        public SendContactEventArgs(Contact contact)
        {
            if(contact == null)
            {
                throw new ArgumentNullException("Contact cannot be null");
            }

            this.Contact = contact;
        }

        public Contact Contact { get; set; }
    }
}
