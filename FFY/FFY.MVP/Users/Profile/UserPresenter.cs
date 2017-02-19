using FFY.Models;
using FFY.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Users.Profile
{
    public class UserPresenter : Presenter<IUserView>
    {
        private readonly IUsersService usersService;

        public UserPresenter(IUserView view, IUsersService usersService) : base(view)
        {
            if(usersService == null)
            {
                throw new ArgumentNullException("Users service cannot be null.");
            }

            this.usersService = usersService;
            this.View.Initial += this.OnInitial;
        }

        private void OnInitial(object sender, UserByIdEventArgs e)
        {
            this.View.Model.User = this.usersService.GetUserById(e.Id);
        }
    }
}
