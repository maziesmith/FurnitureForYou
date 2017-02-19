using System;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using FFY.IdentityConfig;
using WebFormsMvp;
using FFY.MVP.Account.Login;
using WebFormsMvp.Web;
using Microsoft.AspNet.Identity;

namespace FFY.Web.Account
{
    [PresenterBinding(typeof(LoginPresenter))]
    public partial class Login : MvpPage<LoginViewModel>, ILoginView
    {
        public event EventHandler<LoginEventArgs> Logging;
        public event EventHandler<CartCountEventArgs> LoggingCartCount;
        private string userId;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Possibly a better solution - needs explaining
            if (User.Identity.IsAuthenticated)
            {
                this.Response.Redirect("~/Errors/Unauthorized");
            }

            RegisterHyperLink.NavigateUrl = "register";

            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                this.Logging?.Invoke(this, new LoginEventArgs(
                    this.Context, 
                    this.UserName.Text, 
                    this.Password.Text, 
                    this.RememberMe.Checked, 
                    shouldLockOut: false));

                switch (this.Model.SignInStatus)
                {
                    case SignInStatus.Success:
                        this.userId = this.User.Identity.GetUserId();
                        this.LoggingCartCount?.Invoke(this, new CartCountEventArgs(userId));
                        this.Cache.Insert($"cart-count-{userId}", this.Model.CartCount);
                        IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                        break;
                    case SignInStatus.LockedOut:
                        Response.Redirect("/Account/Lockout");
                        break;
                    case SignInStatus.RequiresVerification:
                        Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}", 
                                                        Request.QueryString["ReturnUrl"],
                                                        RememberMe.Checked),
                                          true);
                        break;
                    case SignInStatus.Failure:
                    default:
                        FailureText.Text = "Invalid login attempt";
                        ErrorMessage.Visible = true;
                        break;
                }
            }
        }
    }
}