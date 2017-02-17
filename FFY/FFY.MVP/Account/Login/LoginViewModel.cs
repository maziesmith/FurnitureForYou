using FFY.Order;
using Microsoft.AspNet.Identity.Owin;

namespace FFY.MVP.Account.Login
{
    public class LoginViewModel
    {
        public ShoppingCart ShoppingCart { get; set; }
        public SignInStatus SignInStatus { get; set; }
    }
}
