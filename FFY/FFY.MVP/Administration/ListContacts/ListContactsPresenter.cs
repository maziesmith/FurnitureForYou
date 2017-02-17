using FFY.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Administration.ListContacts
{
    public class ListContactsPresenter : Presenter<IListContactsView>
    {
        private readonly IContactsService contactsService;

        public ListContactsPresenter(IListContactsView view,
            IContactsService contactsService) : base(view)
        {
            if (contactsService == null)
            {
                throw new ArgumentNullException("Contacts service cannot be null");
            }

            this.contactsService = contactsService;
            this.View.ListingContacts += OnListingContacts;
        }

        private void OnListingContacts(object sender, EventArgs e)
        {
            this.View.Model.Contacts = this.contactsService.GetContacts();
        }
    }
}
