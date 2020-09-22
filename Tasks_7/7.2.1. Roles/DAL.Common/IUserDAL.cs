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
        void RegistrationUser(string login, string password, bool admin);
        bool CheckForExistence(string name);
        string GetPassword(string name);
        string[] GetRolesForUser(string username);
        bool IsUserInRole(string username, string roleName);
    }
}
