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
        bool RegistrationUser(string login, string password, bool admin);
        bool CheckForExistence(string name);
        string GetPassword(string name);
        string[] GetRolesForUser(string username);
         bool IsUserInRole(string username, string roleName);
    }
}
