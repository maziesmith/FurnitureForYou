using FFY.MVP.Administration.ContactManagement.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace FFY.Web.Administration.ContactManagement
{
    [PresenterBinding(typeof(ContactsPresenter))]
    public partial class _Default : MvpPage<ContactsViewModel>, IContactsView
    {
        public event EventHandler ListingContacts;
        public event EventHandler<FilterEventArgs> FilterContacts;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.ListingContacts?.Invoke(this, e);
            this.ContactList.DataSource = this.Model.Contacts.ToList();
            this.ContactList.DataBind();
        }

        protected void ContactListPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.ContactList.DataSource = this.Model.Contacts;
            this.ContactList.PageIndex = e.NewPageIndex;
            this.ContactList.DataBind();

        }

        protected void ContactsDropdownSelectedIndexChanged(object sender, EventArgs e)
        {
            this.Filter();
        }

        protected void SearchButtonClick(object sender, EventArgs e)
        {
            this.Filter();
        }

        private void Filter()
        {
            var statusType = int.Parse(this.ContactsDropdown.SelectedValue);
            this.FilterContacts?.Invoke(this, new FilterEventArgs(statusType, this.SearchBox.Text));
            this.ContactList.DataSource = this.Model.Contacts.ToList();
            this.ContactList.DataBind();
        }
    }
}