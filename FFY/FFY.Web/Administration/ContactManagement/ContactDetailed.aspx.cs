using FFY.MVP.Contacts.EditContactStatus;
using Microsoft.AspNet.Identity;
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
    [PresenterBinding(typeof(EditContactStatusPresenter))]
    public partial class ContactDetailed : MvpPage<EditContactStatusViewModel>, IEditContactStatusView
    {
        public event EventHandler<EditContactStatusEventArgs> EdittingContact;
        public event EventHandler<GetContactByIdEventArgs> Initial;

        protected void Page_Load(object sender, EventArgs e)
        {
            // this.Model this.Page.User.Identity.GetUserId();

            var contactIdParameter = this.Page.RouteData.Values["contactId"].ToString();

            int contactId;

            if (!(int.TryParse(contactIdParameter, out contactId)))
            {
                this.Server.Transfer("~/Errors/PageNotFound.aspx");
            }

            this.Initial?.Invoke(this, new GetContactByIdEventArgs(contactId));

            if (this.Model.Contact == null)
            {
                this.Server.Transfer("~/Errors/PageNotFound.aspx");
            }
        }
    }
}