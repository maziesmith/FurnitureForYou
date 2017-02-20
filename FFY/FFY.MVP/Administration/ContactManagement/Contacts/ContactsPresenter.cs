using FFY.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Administration.ContactManagement.Contacts
{
    public class ContactsPresenter : Presenter<IContactsView>
    {
        private readonly IContactsService contactsService;

        public ContactsPresenter(IContactsView view,
            IContactsService contactsService) : base(view)
        {
            if (contactsService == null)
            {
                throw new ArgumentNullException("Contacts service cannot be null");
            }

            this.contactsService = contactsService;
            this.View.ListingContacts += OnListingContacts;
            this.View.FilterContacts += OnFilteringContacts;
        }

        private void OnFilteringContacts(object sender, FilterEventArgs e)
        {
            this.View.Model.Contacts = this.contactsService.GetContactsByStatusTypeAndTitleOrSender(e.StatusType, e.Search);
        }

        private void OnListingContacts(object sender, EventArgs e)
        {
            this.View.Model.Contacts = this.contactsService.GetContacts();
        }
    }
}
