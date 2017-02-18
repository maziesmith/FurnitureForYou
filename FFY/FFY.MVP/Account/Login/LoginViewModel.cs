using Microsoft.AspNet.Identity.Owin;

namespace FFY.MVP.Account.Login
{
    public class LoginViewModel
    {
        public SignInStatus SignInStatus { get; set; }

        public int CartCount { get; set; }
    }
}
