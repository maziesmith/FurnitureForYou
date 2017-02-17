using FFY.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Contacts.EditContactStatus
{
    public class EditContactStatusPresenter : Presenter<IEditContactStatusView>
    {
        private IContactsService contactsService;

        public EditContactStatusPresenter(IEditContactStatusView view,
            IContactsService contactsService) : base(view)
        {
            if(contactsService == null)
            {
                throw new ArgumentNullException("Contacts service cannot be null.");
            }

            this.contactsService = contactsService;
            this.View.Initial += OnInitial;
            this.View.EdittingContact += OnEdittingContact;
        }

        private void OnInitial(object sender, GetContactByIdEventArgs e)
        {
            this.View.Model.Contact = this.contactsService.GetContactById(e.Id);
        }

        private void OnEdittingContact(object sender, EditContactStatusEventArgs e)
        {
            this.contactsService.ChangeContactStatus(e.Contact, e.StatusType, e.UserId);
        }


    }
}
