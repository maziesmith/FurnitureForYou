using FFY.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.ContactManagement.ContactDetailed
{
    public class ContactDetailedPresenter : Presenter<IContactDetailedView>
    {
        private IContactsService contactsService;

        public ContactDetailedPresenter(IContactDetailedView view,
            IContactsService contactsService) : base(view)
        {
            if(contactsService == null)
            {
                throw new ArgumentNullException("Contacts service cannot be null.");
            }

            this.contactsService = contactsService;
            this.View.Initial += OnInitial;
            this.View.EdittingContactStatus += OnEdittingContactStatus;
        }

        private void OnInitial(object sender, GetContactByIdEventArgs e)
        {
            this.View.Model.Contact = this.contactsService.GetContactById(e.Id);
        }

        private void OnEdittingContactStatus(object sender, EditContactStatusEventArgs e)
        {
            this.contactsService.ChangeContactStatus(e.Contact, e.StatusType, e.UserId);
        }


    }
}
