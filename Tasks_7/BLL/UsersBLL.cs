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
        public void DeleteUser(Guid id)
        {
            //throw new NotImplementedException();
        }

        public IEnumerable<Users> GetAllUsers()
        {
            //throw new NotImplementedException();
            // TODO: logging, send messages
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
                // TODO: logging, send messages
                _usersDAL.SaveUser(user);
                return true;
            }
            catch
            {
                // TODO: checking more exceptions
                return false;
            }
        }
    }
}
