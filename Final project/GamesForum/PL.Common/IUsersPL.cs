using Entitiens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Common
{
    public interface IUsersPL
    {
        IEnumerable<User> GetAllUsers();
        User GetUserByID(Guid id);
        User GetUserByName(string nickname);
        bool RegistrationUser(string login, string password, bool admin);
        bool CheckForExistence(string name);
        string GetPassword(string name);
        bool EditReputationUser(Guid idUser, string action);
        bool ChangeUserRole(string nameUser, bool newRole);
        bool DeleteUser(Guid id);
    }
}
