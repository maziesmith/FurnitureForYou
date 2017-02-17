using System.Web;
using Microsoft.AspNet.Identity.Owin;
using WebFormsMvp;
using FFY.IdentityConfig;
using FFY.Order;
using FFY.Order.Factories;
using System;
using FFY.Services.Contracts;

namespace FFY.MVP.Account.Login
{
    public class LoginPresenter : Presenter<ILoginView>
    {
        private readonly ICartProductFactory cartProductFactory;
        private readonly IProductsService productsService;

        public LoginPresenter(ILoginView view, 
            ICartProductFactory cartProductFactory,
            IProductsService productsService) : base(view)
        {
            if(cartProductFactory == null)
            {
                throw new ArgumentNullException("Cart product factory cannot be null.");
            }

            if (productsService == null)
            {
                throw new ArgumentNullException("Products service cannot be null.");
            }

            this.cartProductFactory = cartProductFactory;
            this.productsService = productsService;
            this.View.Logging += this.OnLoggingIn;
        }

        public void OnLoggingIn(object sender, LoginEventArgs e)
        {
            var signinManager = e.Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

            SignInStatus result = signinManager.PasswordSignIn(e.UserName, e.Password, e.RememberMe, e.ShouldLockOut);

            if(result == SignInStatus.Success)
            {
                if(e.Context.Session["shoppingCart"] == null)
                {
                    //TODO: Factory
                    e.Context.Session["shoppingCart"] = new SessionShoppingCart()
                    {
                        ShoppingCart = new ShoppingCart(this.cartProductFactory, this.productsService)
                    };
                }
            }

            this.View.Model.SignInStatus = result;
        }
    }
}
