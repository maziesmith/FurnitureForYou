using FFY.MVP.Users.Profile;
using Microsoft.AspNet.Identity;
using System;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace FFY.Web.Users
{
    [PresenterBinding(typeof(ProfilePresenter))]
    public partial class Profile : MvpPage<ProfileViewModel>, IProfileView
    {
        public event EventHandler<ProfileByIdEventArgs> GettingUserById;

        protected void Page_Load(object sender, EventArgs e)
        {
            var id = this.Page.User.Identity.GetUserId();
            this.GettingUserById?.Invoke(this, new ProfileByIdEventArgs(id));

            this.TestLbl.Text = this.Model.User.ShoppingCart.Total.ToString();
        }
    }
}