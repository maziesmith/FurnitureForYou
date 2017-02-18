using FFY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.ContactManagement.ContactDetailed
{
    public class EditContactStatusEventArgs : EventArgs
    {
        public EditContactStatusEventArgs(Contact contact, int statusType, string userId)
        {
            this.Contact = contact;
            this.StatusType = statusType;
            this.UserId = userId;
        }

        public Contact Contact { get; set; }

        public int StatusType { get; set; }

        public string UserId { get; set; }
    }
}
