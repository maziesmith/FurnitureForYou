using FFY.MVP.Administration.UserManagement.Users;
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
    [PresenterBinding(typeof(UsersPresenter))]
    public partial class _Default : MvpPage<UsersViewModel>, IUsersView
    {
        public event EventHandler ListingUsers;
        public event EventHandler<FilterEventArgs> FilterUsers;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                this.ListingUsers?.Invoke(this, e);
                this.UserList.DataSource = this.Model.Users.ToList();
                this.UserList.DataBind();
            }
        }

        protected void UserListPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.Filter();
            this.UserList.PageIndex = e.NewPageIndex;
            this.UserList.DataBind();
        }

        protected void UsersDropdownSelectedIndexChanged(object sender, EventArgs e)
        {
            this.Filter();
        }

        protected void SearchButtonClick(object sender, EventArgs e)
        {
            this.Filter();
        }

        private void Filter()
        {
            var roleType = int.Parse(this.UsersDropdown.SelectedValue);
            this.FilterUsers?.Invoke(this, new FilterEventArgs(roleType, this.SearchBox.Text));
            this.UserList.DataSource = this.Model.Users.ToList();
            this.UserList.DataBind();
        }
    }
}