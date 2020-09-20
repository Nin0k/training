using Entitiens;
using System;
using System.Collections.Generic;

namespace DAL.Common
{
    public interface IUserDAL
    {
        void SaveUser(Users user);
        void DeleteUser(Guid id);
        IEnumerable<Users> GetAllUsers();
        Users GetUserByID(Guid id);
    }
}
