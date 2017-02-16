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
    }
}
