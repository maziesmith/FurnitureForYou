using FFY.MVP.Users.Profile;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace FFY.Web.Users
{
    [PresenterBinding(typeof(UserPresenter))]
    public partial class Profile : MvpPage<UserViewModel>, IUserView
    {
        public event EventHandler<UserByIdEventArgs> Initial;

        protected void Page_Load(object sender, EventArgs e)
        {
            var id = this.Page.User.Identity.GetUserId();
            this.Initial?.Invoke(this, new UserByIdEventArgs(id));

            this.OrderList.DataSource = this.Model.User.Orders.Reverse().ToList();
            this.OrderList.DataBind();
        }

        protected void OrderListPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.OrderList.PageIndex = e.NewPageIndex;
            this.OrderList.DataBind();
        }
    }
}