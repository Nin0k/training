using Entitiens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Common
{
    public interface IUsersDAL
    {
        User GetUserByID(Guid id);
        string GetPassword(string name);
        string[] GetRolesForUser(string username);
        bool IsUserInRole(string username, string roleName);
        void RegistrationUser(User user);
        bool CheckForExistence(string name);
        void EditUser(User user);
    }
}
