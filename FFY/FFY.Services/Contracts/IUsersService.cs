using FFY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.Services.Contracts
{
    public interface IUsersService
    {
        User GetUserById(string id);

        User GetUserByUsername(string username);
    }
}
