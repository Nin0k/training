using System;
using BLL.Common;
using BLL.Dependencies;
using Entitiens;
using PL.Common;
using System.Globalization;
using System.Collections.Generic;

namespace Tasks_7
{
    public class ConsoleUserPL : IUserPL
    {

        private IUserBLL _bll;
        private readonly CultureInfo cultureInfo = new CultureInfo("en-US");
        private readonly DateTimeStyles styles = 0;

        public ConsoleUserPL()
        {
            _bll = DependenciesBLL.UserBLL;
        }
        public bool AddUser()
        {
            Console.WriteLine("Добавление нового пользователя..." + Environment.NewLine);
            Console.Write("Введите имя:");
            string name = Console.ReadLine();

            Console.Write("Введите дату рождения (формат ввода: mm/dd/yyyy):");
            string data = Console.ReadLine();

            if (DateTime.TryParse(data, cultureInfo, styles, out DateTime birthday))
            {
                return _bll.SaveUser(new Users(name, birthday));
            }
            else
            {
                Console.WriteLine("Неверная дата. Пользователь не сохранен!");
                return false;
            }

        }

        public bool DeleteUser()
        {
            Console.WriteLine("Удаление пользователя..." + Environment.NewLine);
            Guid id = SelectedUser();
            return _bll.DeleteUser(id);
        }

        public void DisplayAllUsers()
        {
            var users = _bll.GetAllUsers();

            Console.WriteLine("Сохраненные пользователи:" + Environment.NewLine);
        
            foreach (Users item in users)
            {
                Console.WriteLine(string.Format("Имя: {0}, Дата рождения: {1}, Возраст: {2}",
                    item.Name, item.DateOfBirth, item.Age));
                }
        }

        public Guid SelectedUser()
        {
            Dictionary<int, Guid> ID = new Dictionary<int, Guid>();
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

            if (int.TryParse(Console.ReadLine(), out int number) && number > 0 && number < serialNumber )
            {
                return ID[number];
            }
            else
            {
                throw new ArgumentOutOfRangeException("number");
            }
        }
    }
}
