using FFY.MVP.Administration.ListContacts;
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
    [PresenterBinding(typeof(ListContactsPresenter))]
    public partial class _Default : MvpPage<ListContactsViewModel>, IListContactsView
    {
        public event EventHandler ListingContacts;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.ListingContacts?.Invoke(this, e);

            if (!Page.IsPostBack)
            {
                this.ContactList.DataSource = this.Model.Contacts;
                this.ContactList.DataBind();
            }
        }

        protected void ContactListPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.ContactList.PageIndex = e.NewPageIndex;
            this.ContactList.DataBind();
        }
    }
}