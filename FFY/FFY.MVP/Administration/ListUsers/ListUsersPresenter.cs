using FFY.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Administration.ListUsers
{
    public class ListUsersPresenter : Presenter<IListUsersView>
    {
        private readonly IUsersService usersService;
        public ListUsersPresenter(IListUsersView view,
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
