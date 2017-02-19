using FFY.MVP.ContactManagement.ContactDetailed;
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
    [PresenterBinding(typeof(ContactDetailedPresenter))]
    public partial class ContactDetailed : MvpPage<ContactDetailedViewModel>, IContactDetailedView
    {
        public event EventHandler<EditContactStatusEventArgs> EdittingContactStatus;
        public event EventHandler<GetContactByIdEventArgs> Initial;

        protected void Page_Load(object sender, EventArgs e)
        {
            string contactIdParameter = null;

            if (this.Page.RouteData.Values["contactId"] != null)
            {
                contactIdParameter = this.Page.RouteData.Values["contactId"].ToString();
            }

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

            if (!Page.IsPostBack)
            {
                this.BindData();
            }
        }

        protected void EditContactStatus(object sender, EventArgs e)
        {
            var userId = this.User.Identity.GetUserId();
            var statusType = int.Parse(this.StatusType.SelectedValue);

            this.EdittingContactStatus?.Invoke(this, new EditContactStatusEventArgs(this.Model.Contact, statusType, userId));
            this.BindData();
        }

        private void BindData()
        {
            if (this.Model.Contact.UserProcessedBy != null)
            {
                this.ProccessedBy.Text =
                    $"{this.Model.Contact.UserProcessedBy.FirstName} {this.Model.Contact.UserProcessedBy.LastName}";
            }
            else
            {
                this.ProccessedBy.Text = "Not proccessed";
            }

            this.StatusType.SelectedValue = ((int)this.Model.Contact.ContactStatusType).ToString();
            this.StatusType.DataBind();
        }
    }
}