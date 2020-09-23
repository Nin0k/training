using BLL.Common;
using DAL.Common;
using DAL.Dependencies;
using Entitiens;
using System;
using System.Collections.Generic;
namespace BLL
{
    public class UsersBLL : IUserBLL
    {
        
        private IUserDAL _usersDAL;
        public UsersBLL()
        {
            _usersDAL = DependenciesDAL.UserDAL;
        }
        public bool DeleteUser(Guid id)
        {
            try
            {
                _usersDAL.DeleteUser(id);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public IEnumerable<Users> AllUsers => _usersDAL.GetAllUsers();

        public Users GetUserByID(Guid id) => _usersDAL.GetUserByID(id);

        public bool SaveUser(Users user)
        {
            try
            {
                _usersDAL.SaveUser(user);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool EditUser(Guid id, string name, DateTime data)
        {
            try
            {
                Users newUser = new Users(name, data)
                {
                    ID = id
                };
                _usersDAL.SaveUser(newUser);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool RegistrationUser(string login, string password, bool admin)
        {
            try
            {
                _usersDAL.RegistrationUser(login, password, admin);
                return true;
            }
            catch
            {
                return false;
            }
        }

       public bool CheckForExistence(string name) => _usersDAL.CheckForExistence(name);

        public string GetPassword(string name) => _usersDAL.GetPassword(name);
        public string[] GetRolesForUser(string username) => _usersDAL.GetRolesForUser(username);
        public bool IsUserInRole(string username, string roleName) => _usersDAL.IsUserInRole(username, roleName);
    }
}
