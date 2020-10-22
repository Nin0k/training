using BLL.Common;
using DAL.Common;
using DAL.Dependencies;
using Entitiens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Logic
{
    public class UsersBLL : IUsersBLL
    {
        private IUsersDAL _usersDAL;
        public UsersBLL()
        {
            _usersDAL = DependenciesDAL.UsersDAL;
        }
        public User GetUserByID(Guid id) => _usersDAL.GetUserByID(id);
        public string[] GetRolesForUser(string username) => _usersDAL.GetRolesForUser(username);
        public bool IsUserInRole(string username, string roleName) => _usersDAL.IsUserInRole(username, roleName);
        public bool RegistrationUser(string login, string password, bool admin)
        {
            try
            {
                User user = new User(login, admin, password);
                _usersDAL.RegistrationUser(user);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CheckForExistence(string name) => _usersDAL.CheckForExistence(name);

        public string GetPassword(string name) => _usersDAL.GetPassword(name);
        public bool EditReputationUser(Guid idUser, string action)
        {
            try
            {
                User user = GetUserByID(idUser);
                int reputation = user.Reputation;

                if (action == "+")
                {
                    reputation++;
                }
                else if (action == "-")
                {
                    reputation--;
                }
                user.Reputation = reputation;
                _usersDAL.EditUser(user);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
