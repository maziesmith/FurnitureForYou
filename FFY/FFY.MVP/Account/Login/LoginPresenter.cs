using System.Web;
using Microsoft.AspNet.Identity.Owin;
using WebFormsMvp;
using FFY.IdentityConfig;

namespace FFY.MVP.Account.Login
{
    public class LoginPresenter : Presenter<ILoginView>
    {
        public LoginPresenter(ILoginView view) : base(view)
        {
            this.View.Logging += this.Logging;
        }

        public void Logging(object sender, LoginEventArgs e)
        {
            var signinManager = e.Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

            var result = signinManager.PasswordSignIn(e.UserName, e.Password, e.RememberMe, e.ShouldLockOut);

            this.View.Model.SignInStatus = result;
        }
    }
}
