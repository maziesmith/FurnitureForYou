using System;
using System.Linq;
using FFY.IdentityConfig;
using WebFormsMvp;
using FFY.MVP.Account.Register;
using WebFormsMvp.Web;

namespace FFY.Web.Account
{
    [PresenterBinding(typeof(RegisterPresenter))]
    public partial class Register : MvpPage<RegisterViewModel>, IRegisterView
    {
        private const string DefaultUserRole = "User";
        public event EventHandler<RegisterEventArgs> Registering;
        public event EventHandler<SignInEventArgs> SigningIn;

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var username = this.UserName.Text;
            var firstName = this.FirstName.Text;
            var lastName = this.LastName.Text;
            var email = this.Email.Text;
            var userRole = DefaultUserRole;
            var password = this.Password.Text;

            this.Registering?.Invoke(this, new RegisterEventArgs(this.Context, 
                username, 
                firstName, 
                lastName,
                email,
                userRole,
                password));

            if (this.Model.IdentityResult.Succeeded)
            {

                this.SigningIn?.Invoke(this, new SignInEventArgs(this.Context,
                username,
                firstName,
                lastName,
                email,
                userRole));

                this.Cache.Insert($"cart-count-{this.Model.UserId}", 0);

                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else 
            {
                ErrorMessage.Text = this.Model.IdentityResult.Errors.FirstOrDefault();
            }
        }
    }
}