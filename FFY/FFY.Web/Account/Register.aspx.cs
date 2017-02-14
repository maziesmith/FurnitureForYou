using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using FFY.Models;
using FFY.IdentityConfig;
using WebFormsMvp;
using FFY.MVP.Account.Register;
using WebFormsMvp.Web;

namespace FFY.Web.Account
{
    [PresenterBinding(typeof(RegisterPresenter))]
    public partial class Register : MvpPage<RegisterViewModel>, IRegisterView
    {
        public event EventHandler<RegisterEventArgs> Registering;
        public event EventHandler<SignInEventArgs> SigningIn;

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var user = new User()
            {
                UserName = this.UserName.Text,
                FirstName = this.FirstName.Text,
                LastName = this.LastName.Text,
                Email = this.Email.Text,
            };

            this.Registering?.Invoke(this, new RegisterEventArgs(this.Context, user, this.Password.Text));

            if (this.Model.IdentityResult.Succeeded)
            {
                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                //string code = manager.GenerateEmailConfirmationToken(user.Id);
                //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

                this.SigningIn?.Invoke(this, new SignInEventArgs(this.Context, user));
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else 
            {
                ErrorMessage.Text = this.Model.IdentityResult.Errors.FirstOrDefault();
            }
        }
    }
}