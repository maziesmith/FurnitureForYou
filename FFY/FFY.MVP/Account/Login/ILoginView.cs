using System;
using WebFormsMvp;

namespace FFY.MVP.Account.Login
{
    public interface ILoginView : IView<LoginViewModel>
    {
        event EventHandler<LoginEventArgs> Logging;

        event EventHandler<CartCountEventArgs> LoggingCartCount;
    }
}
