using FFY.Data.Factories;
using FFY.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Contacts.ContactSender
{
    public class ContactPresenter : Presenter<IContactView>
    {
        private readonly IContactsService contactsService;
        private readonly IContactFactory contactFactory;

        public ContactPresenter(IContactView view,
            IContactFactory contactFactory,
            IContactsService contactsService) : base(view)
        {
            if(contactsService == null)
            {
                throw new ArgumentNullException("Contacts service cannot be null.");
            }

            if (contactFactory == null)
            {
                throw new ArgumentNullException("Contact factory cannot be null.");
            }

            this.contactsService = contactsService;
            this.contactFactory = contactFactory;
            this.View.SendingContact += OnSendingContact;
        }

        private void OnSendingContact(object sender, ContactEventArgs e)
        {
            var contact = this.contactFactory.CreateContact(e.Title, e.Email, e.EmailContent, e.SendOn, e.StatusType);
            this.contactsService.AddContact(contact);
        }
    }
}
