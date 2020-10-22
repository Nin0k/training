using Entitiens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Common
{
    public interface IUsersBLL
    {
        User GetUserByID(Guid id);
        User GetUserByName(string nickname);
        string[] GetRolesForUser(string username);
        bool IsUserInRole(string username, string roleName);
        bool RegistrationUser(string login, string password, bool admin);
        bool CheckForExistence(string name);
        string GetPassword(string name);
        bool EditReputationUser(Guid idUser, string action);
    }
}
