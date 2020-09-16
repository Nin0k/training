using BLL.Common;
using DAL.Common;
using DAL.Dependencies;
using Entitiens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public IEnumerable<Users> GetAllUsers()
        {
            return _usersDAL.GetAllUsers();
        }

        public Users GetUserByID(Guid id)
        {
            return _usersDAL.GetUserByID(id);
        }

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
    }
}
