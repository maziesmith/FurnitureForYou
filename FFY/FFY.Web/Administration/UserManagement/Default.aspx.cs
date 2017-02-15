using FFY.MVP.Administration.ListUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace FFY.Web.Administration.UserManagement
{
    [PresenterBinding(typeof(ListUsersPresenter))]
    public partial class _Default : MvpPage<ListUsersViewModel>, IListUsersView
    {
        public event EventHandler ListingUsers;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.ListingUsers?.Invoke(this, e);

            if(!Page.IsPostBack)
            {
                this.UserList.DataSource = this.Model.Users;
                this.UserList.DataBind();
            }
        }

        protected void UserListPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.UserList.PageIndex = e.NewPageIndex;
            this.UserList.DataBind();
        }
    }
}