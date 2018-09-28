using PS.Core.Entities.Other;
using PS.Core.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Core.Service.Interface
{
    public interface IUserService
    {
        IEnumerable<User> getUsers();
        bool register(LogInInfo log, User aUser);
        bool blockUser(int userId);
    }
}
