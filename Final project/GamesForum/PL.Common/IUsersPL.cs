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
        User GetUserByID(Guid id);
        bool RegistrationUser(string login, string password, bool admin);
        bool CheckForExistence(string name);
        string GetPassword(string name);
        bool EditReputationUser(Guid idUser, string action);
    }
}
