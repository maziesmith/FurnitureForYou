using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Administration.ContactManagement.Contacts
{
    public interface IContactsView : IView<ContactsViewModel>
    {
        event EventHandler ListingContacts;

        event EventHandler<FilterEventArgs> FilterContacts;
    }
}
