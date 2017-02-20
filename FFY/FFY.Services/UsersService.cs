using FFY.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FFY.Models;
using FFY.Data.Contracts;

namespace FFY.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IGenericRepository<User> usersRepository;


        public UsersService(IUnitOfWork unitOfWork, IGenericRepository<User> usersRepository)
        {
            if(unitOfWork == null)
            {
                throw new ArgumentNullException("Unit of work cannot be null.");
            }

            if(usersRepository == null)
            {
                throw new ArgumentNullException("Users repository cannot be null.");
            }

            this.unitOfWork = unitOfWork;
            this.usersRepository = usersRepository;
        }

        public void ChangeUserRole(User user)
        {
            if(user == null)
            {
                throw new ArgumentNullException("User cannot be null.");
            }

            using (this.unitOfWork)
            {
                this.usersRepository.Update(user);
                this.unitOfWork.Commit();
            }

        }

        public User GetUserById(string id)
        {
            return this.usersRepository.GetById(id);
        }

        public User GetUserByUsername(string username)
        {
            return this.usersRepository.GetAll(u => u.UserName == username).FirstOrDefault();
        }

        public IEnumerable<User> GetUsers()
        {
            return this.usersRepository.GetAll();
        }

        public IEnumerable<User> GetUsersByRoleTypeAndName(int roleType, string search)
        {
            var users = this.usersRepository.GetAll();

            if (!string.IsNullOrEmpty("search"))
            {
                users = users.Where(u =>
                    u.UserName.ToLower().Contains(search.ToLower()) ||
                    u.LastName.ToLower().Contains(search.ToLower()) ||
                    u.LastName.ToLower().Contains(search.ToLower()) ||
                    u.Email.ToLower().Contains(search.ToLower()));
            }

            if (roleType == 0)
            {
                return users;
            }
            else
            {
                if (!Enum.IsDefined(typeof(UserRoleType), roleType))
                {
                    throw new InvalidCastException("Contact status type is out of enumeration range.");
                }

                var userRoleType = (UserRoleType)roleType;

                return users.Where(u => u.UserRole == userRoleType.ToString());
            }
        }
    }
}
