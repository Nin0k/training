using Entitiens;
using System;
using System.Collections.Generic;

namespace BLL.Common
{
    public interface IUserBLL
    {
        bool SaveUser(Users user);
        bool DeleteUser(Guid id);
        IEnumerable<Users> AllUsers { get; }

        Users GetUserByID(Guid id);
        bool EditUser(Guid id, string name, DateTime data);
    }
}
