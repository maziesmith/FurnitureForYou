using System;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using FFY.IdentityConfig;
using WebFormsMvp;
using FFY.MVP.Account.Login;
using WebFormsMvp.Web;

namespace FFY.Web.Account
{
    [PresenterBinding(typeof(LoginPresenter))]
    public partial class Login : MvpPage<LoginViewModel>, ILoginView
    {
        public event EventHandler<LoginEventArgs> Logging;

        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            // Enable this once you have account confirmation enabled for password reset functionality
            //ForgotPasswordHyperLink.NavigateUrl = "Forgot";
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
                var signinManager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

                this.Logging?.Invoke(this, new LoginEventArgs(
                    this.Context, 
                    this.UserName.Text, 
                    this.Password.Text, 
                    this.RememberMe.Checked, 
                    shouldLockOut: false));

                switch (this.Model.SignInStatus)
                {
                    case SignInStatus.Success:
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