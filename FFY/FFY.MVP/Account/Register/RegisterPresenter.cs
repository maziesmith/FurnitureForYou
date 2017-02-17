using FFY.Data.Factories;
using FFY.IdentityConfig;
using FFY.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Web;
using WebFormsMvp;

namespace FFY.MVP.Account.Register
{
    public class RegisterPresenter : Presenter<IRegisterView>
    {
        private readonly IUserFactory userFactory;
        private User user;

        public RegisterPresenter(IRegisterView view,
            IUserFactory userFactory) : base(view)
        {
            if(userFactory == null)
            {
                throw new ArgumentNullException("User factory cannot be null.");
            }
            this.userFactory = userFactory;
            this.View.Registering += OnRegistering;
            this.View.SigningIn += OnSigningIn;
        }

        public void OnRegistering(object sender, RegisterEventArgs e)
        {
            var manager = e.Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = e.Context.GetOwinContext().Get<ApplicationSignInManager>();

            this.user = this.userFactory.CreateUser(e.Username, e.FirstName, e.LastName, e.Email, e.UserRole);
            var pass = e.Password;

            IdentityResult result = manager.Create(user, e.Password);

            if(result.Succeeded)
            {
                manager.AddToRole(user.Id, "User");
            }

            this.View.Model.IdentityResult = result;
        }

        private void OnSigningIn(object sender, SignInEventArgs e)
        {
            var signInManager = e.Context.GetOwinContext().Get<ApplicationSignInManager>();

            signInManager.SignIn(this.user, isPersistent: false, rememberBrowser: false);

        }
    }
}
