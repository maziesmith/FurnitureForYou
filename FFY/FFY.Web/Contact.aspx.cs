using FFY.Models;
using FFY.MVP.Contacts.ContactSender;
using FFY.Order;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
            var cart = this.Session[string.Format("cart-{0}", this.User.Identity.GetUserName())] as SessionShoppingCart;
            this.TestLbl.Text = cart.ShoppingCart.Total().ToString();
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
            }
        }
    }
}