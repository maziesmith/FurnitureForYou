using FFY.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Users.SendContact
{
    public class SendContactPresenter : Presenter<ISendContactView>
    {
        private readonly IContactsService contactsService;
        public SendContactPresenter(ISendContactView view,
            IContactsService contactsService) : base(view)
        {
            if(contactsService == null)
            {
                throw new ArgumentNullException("Contacts service cannot be null");
            }

            this.contactsService = contactsService;
            this.View.SendingContact += OnSendingContact;
        }

        private void OnSendingContact(object sender, SendContactEventArgs e)
        {
            this.contactsService.AddContact(e.Contact);
        }
    }
}
