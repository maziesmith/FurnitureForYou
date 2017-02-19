using System.Web;
using Microsoft.AspNet.Identity.Owin;
using WebFormsMvp;
using FFY.IdentityConfig;
using System;
using FFY.Services.Contracts;
using Microsoft.AspNet.Identity;

namespace FFY.MVP.Account.Login
{
    public class LoginPresenter : Presenter<ILoginView>
    {
        private readonly IShoppingCartsService shoppingCartsService;

        public LoginPresenter(ILoginView view,
            IShoppingCartsService shoppingCartsService) : base(view)
        {
            if(shoppingCartsService == null)
            {
                throw new ArgumentNullException("Shopping carts service cannot be null.");
            }

            this.shoppingCartsService = shoppingCartsService;
            this.View.Logging += this.OnLoggingIn;
            this.View.LoggingCartCount += this.OnLoggingCartCount;
        }

        private void OnLoggingCartCount(object sender, CartCountEventArgs e)
        {
            this.View.Model.CartCount = this.shoppingCartsService.CartProductsCount(e.CartId);
        }

        public void OnLoggingIn(object sender, LoginEventArgs e)
        {
            var signinManager = e.Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

            SignInStatus result = signinManager.PasswordSignIn(e.UserName, e.Password, e.RememberMe, e.ShouldLockOut);

            this.View.Model.SignInStatus = result;
        }
    }
}
