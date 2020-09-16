using BLL.Common;
using BLL.Dependencies;
using Entitiens;
using PL.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace PL.Web
{
    public class WebUsersPL : IUserPL
    {
        private IUserBLL _bll;
        private readonly CultureInfo cultureInfo = new CultureInfo("en-US");
        private readonly DateTimeStyles styles = 0;

        public WebUsersPL()
        {
            _bll = DependenciesBLL.UserBLL;
        }
        public bool AddUser(string name, string data)
        {
            if (DateTime.TryParse(data, cultureInfo, styles, out DateTime birthday))
            {
                return _bll.SaveUser(new Users(name, birthday));
            }
            else
            {
                return false;
            }
        }

        public bool DeleteUser(Guid id)
        {
            return _bll.DeleteUser(id);
        }

        public IEnumerable<Users> DisplayAllUsers()
        {
            return _bll.GetAllUsers();

        }

        public Guid SelectedUser()
        {
            return new Guid();
           /* Dictionary<int, Guid> ID = new Dictionary<int, Guid>();
            var users = _bll.GetAllUsers();

            Console.WriteLine("Выберите пользователя:" + Environment.NewLine);
            int serialNumber = 1;

            foreach (Users item in users)
            {
                Console.WriteLine(string.Format("Пользователь №{0}. Имя: {1}, Дата рождения: {2}, Возраст: {3}",
                        serialNumber, item.Name, item.DateOfBirth, item.Age));
                ID.Add(serialNumber, item.ID);
                serialNumber++;
            }

            if (int.TryParse(Console.ReadLine(), out int number) && number > 0 && number < serialNumber)
            {
                return ID[number];
            }
            else
            {
                throw new ArgumentOutOfRangeException("number");
            }*/
        }
    }
}