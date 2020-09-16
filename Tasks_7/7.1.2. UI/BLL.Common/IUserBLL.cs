using Entitiens;
using System;
using System.Collections.Generic;

namespace BLL.Common
{
    public interface IUserBLL
    {
        bool SaveUser(Users user);
        bool DeleteUser(Guid id);
        IEnumerable<Users> GetAllUsers();
        Users GetUserByID(Guid id);
    }
}
