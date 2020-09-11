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
        private CultureInfo cultureInfo = new CultureInfo("en-US");
        private DateTimeStyles styles = 0;

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
            int.TryParse(Console.ReadLine(), out int number);
            /*if ((int.TryParse(Console.ReadLine(), out int number)) && number > 0 && number < serialNumber - 1)
            {
                
            }
            else
            {
                Console.WriteLine("Такого пользователя нет.");
                
            }*/
            return ID[number];

        }
    }
}
