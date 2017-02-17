using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Administration.ListContacts
{
    public interface IListContactsView : IView<ListContactsViewModel>
    {
        event EventHandler ListingContacts;
    }
}
