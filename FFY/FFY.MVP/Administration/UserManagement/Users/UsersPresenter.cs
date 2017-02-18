using FFY.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Administration.UserManagement.Users
{
    public class UsersPresenter : Presenter<IUsersView>
    {
        private readonly IUsersService usersService;
        public UsersPresenter(IUsersView view,
            IUsersService usersService) : base(view)
        {
            if(usersService == null)
            {
                throw new ArgumentNullException("Users service cannot be null");
            }

            this.usersService = usersService;
            this.View.ListingUsers += OnListingUsers;
        }

        private void OnListingUsers(object sender, EventArgs e)
        {
            this.View.Model.Users = usersService.GetUsers();
        }
    }
}
