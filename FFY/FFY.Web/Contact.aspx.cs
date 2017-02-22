using FFY.Models;
using FFY.MVP.Contacts.ContactSender;
using System;
using System.Web.UI;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace FFY.Web
{
    [PresenterBinding(typeof(ContactPresenter))]
    public partial class Contact : MvpPage<ContactViewModel>, IContactView
    {
        public event EventHandler<ContactEventArgs> SendingContact;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void SendContactClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var title = this.EmailTitle.Text;
                var email = this.Email.Text;
                var emailContent = this.EmailContent.Text;
                var sendOn = DateTime.Now;
                var contactStatusType = ContactStatusType.NotProcessed;

                this.SendingContact?.Invoke(this, 
                    new ContactEventArgs(title, email, emailContent, sendOn, contactStatusType));

                this.Response.Redirect("~/");
            }
        }
    }
}