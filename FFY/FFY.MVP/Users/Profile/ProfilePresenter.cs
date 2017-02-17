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
    public class ProfilePresenter : Presenter<IProfileView>
    {
        private readonly IUsersService usersService;

        public ProfilePresenter(IProfileView view, IUsersService usersService) : base(view)
        {
            if(usersService == null)
            {
                throw new ArgumentNullException("Users service cannot be null.");
            }

            this.usersService = usersService;
            this.View.GettingUserById += this.OnGettingUserById;
        }

        private void OnGettingUserById(object sender, ProfileByIdEventArgs e)
        {
            this.View.Model.User = this.usersService.GetUserById(e.Id);
        }
    }
}
