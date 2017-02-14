using FFY.IdentityConfig;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Web;
using WebFormsMvp;

namespace FFY.MVP.Account.Register
{
    public class RegisterPresenter : Presenter<IRegisterView>
    {

        public RegisterPresenter(IRegisterView view) : base(view)
        {
            this.View.Registering += OnRegistering;
            this.View.SigningIn += OnSigningIn;
        }

        public void OnRegistering(object sender, RegisterEventArgs e)
        {
            var manager = e.Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = e.Context.GetOwinContext().Get<ApplicationSignInManager>(); 

            IdentityResult result = manager.Create(e.User, e.Password);

            this.View.Model.IdentityResult = result;
        }

        private void OnSigningIn(object sender, SignInEventArgs e)
        {
            var signInManager = e.Context.GetOwinContext().Get<ApplicationSignInManager>();

            signInManager.SignIn(e.User, isPersistent: false, rememberBrowser: false);

        }
    }
}
