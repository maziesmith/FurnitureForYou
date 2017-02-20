using FFY.IdentityConfig;
using FFY.Services.Contracts;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebFormsMvp;

namespace FFY.MVP.Administration.UserManagement.UserDetailed
{
    public class UserDetailedPresenter : Presenter<IUserDetailedView>
    {
        private readonly IUsersService usersService;

        public UserDetailedPresenter(IUserDetailedView view,
            IUsersService usersService) : base(view)
        {
            if(usersService == null)
            {
                throw new ArgumentNullException("Users service cannot be null.");
            }

            this.usersService = usersService;
            this.View.Initial += OnInitial;
            this.View.EdittingUserRole += OnEdditingUserRole;
        }

        private void OnEdditingUserRole(object sender, EditUserRoleEventArgs e)
        {
            var manager = e.Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

            manager.RemoveFromRole(e.User.Id, e.User.UserRole);
            manager.AddToRole(e.User.Id, e.RoleType);

            e.User.UserRole = e.RoleType;
            this.usersService.ChangeUserRole(e.User);

        }

        private void OnInitial(object sender, GetUserByIdEventArgs e)
        {
            this.View.Model.User = this.usersService.GetUserById(e.Id);
        }
    }
}
