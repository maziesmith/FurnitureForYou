using FFY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Administration.ContactManagement.Contacts
{
    public class ContactsViewModel
    {
        public IEnumerable<Contact> Contacts { get; set; }
    }
}
