using BLL.Common;
using BLL.Dependencies;
using Entitiens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PL.Web
{
    public class WebUsersPL
    {
        private IUsersBLL _bll;
        public WebUsersPL() => _bll = DependenciesBLL.UsersBLL;
        public IEnumerable<User> GetAllUsers() => _bll.GetAllUsers();
        public User GetUserByID(Guid id) => _bll.GetUserByID(id);
        public User GetUserByName(string nickname) => _bll.GetUserByName(nickname);
        public bool RegistrationUser(string login, string password, bool admin) => _bll.RegistrationUser(login, password, admin);
        public bool CheckForExistence(string name) => _bll.CheckForExistence(name);
        public string GetPassword(string name) => _bll.GetPassword(name);
        public bool EditReputationUser(Guid idUser, string action) => _bll.EditReputationUser(idUser, action);
        public bool ChangeUserRole(string nameUser, bool newRole) => _bll.ChangeUserRole(nameUser, newRole);
        public bool DeleteUser(Guid id) => _bll.DeleteUser(id);
    }
}