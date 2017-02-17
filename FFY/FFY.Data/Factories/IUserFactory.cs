using FFY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.Data.Factories
{
    public interface IUserFactory
    {
        User CreateUser(string username,
            string firstName,
            string lastName,
            string email,
            string userRole);
    }
}
