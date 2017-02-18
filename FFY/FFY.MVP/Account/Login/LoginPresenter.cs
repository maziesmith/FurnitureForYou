using System.Web;
using Microsoft.AspNet.Identity.Owin;
using WebFormsMvp;
using FFY.IdentityConfig;
using FFY.Order;
using FFY.Order.Factories;
using System;
using FFY.Services.Contracts;
using Microsoft.AspNet.Identity;

namespace FFY.MVP.Account.Login
{
    public class LoginPresenter : Presenter<ILoginView>
    {

        public LoginPresenter(ILoginView view) : base(view)
        {
            this.View.Logging += this.OnLoggingIn;
        }

        public void OnLoggingIn(object sender, LoginEventArgs e)
        {
            var signinManager = e.Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

            SignInStatus result = signinManager.PasswordSignIn(e.UserName, e.Password, e.RememberMe, e.ShouldLockOut);

            this.View.Model.SignInStatus = result;
        }
    }
}
