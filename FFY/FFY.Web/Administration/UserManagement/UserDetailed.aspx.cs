using FFY.MVP.Administration.UserManagement.UserDetailed;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace FFY.Web.Administration.UserManagement
{
    [PresenterBinding(typeof(UserDetailedPresenter))]
    public partial class UserDetailed : MvpPage<UserDetailedViewModel>, IUserDetailedView
    {
        public event EventHandler<GetUserByIdEventArgs> Initial;
        public event EventHandler<EditUserRoleEventArgs> EdittingUserRole;

        protected void Page_Load(object sender, EventArgs e)
        {
            string userIdParameter = null;

            if (this.Page.RouteData.Values["userId"] != null)
            {
                userIdParameter = this.Page.RouteData.Values["userId"].ToString();
            }

            this.Initial?.Invoke(this, new GetUserByIdEventArgs(userIdParameter));

            if (this.Model.User == null)
            {
                this.Server.Transfer("~/Errors/PageNotFound.aspx");
            }

            if (!Page.IsPostBack)
            {
                this.BindData();
            }
        }
        protected void OrderListPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.OrderList.PageIndex = e.NewPageIndex;
            this.OrderList.DataBind();
        }

        protected void EditUserStatus(object sender, EventArgs e)
        {
            var roleType = this.UsersDropdown.SelectedValue;

            this.EdittingUserRole?.Invoke(this, new EditUserRoleEventArgs(this.Context, this.Model.User, roleType));

            this.Response.Redirect("~/administration/userManagement");
        }

        private void BindData()
        {
            this.OrderList.DataSource = this.Model.User.Orders.ToList();
            this.OrderList.DataBind();

            this.UsersDropdown.SelectedValue = this.Model.User.UserRole;
            this.UsersDropdown.DataBind();
        }
    }
}