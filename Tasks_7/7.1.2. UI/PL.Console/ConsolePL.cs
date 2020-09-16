using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
namespace Tasks_7
{
    public class ConsolePL
    {
        static void Main(string[] args)
        {
            ConsoleUserPL user = new ConsoleUserPL();
            ConsoleAwardPL award = new ConsoleAwardPL();
            ConsoleRewardPL reward = new ConsoleRewardPL();

            while (true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("\t 1. Добавить пользователя.");
                Console.WriteLine("\t 2. Вывести всех пользователей.");
                Console.WriteLine("\t 3. Удалить пользователя.");
                Console.Write(Environment.NewLine);
                Console.WriteLine("\t 4. Добавить награду.");
                Console.WriteLine("\t 5. Вывести все награды.");
                Console.WriteLine("\t 6. Удалить награду.");
                Console.Write(Environment.NewLine);
                Console.WriteLine("\t 7. Вручить пользователю награду.");
                Console.WriteLine("\t 8. Вывести пользователей с наградами.");
                Console.Write(Environment.NewLine);
                if (int.TryParse(Console.ReadLine(), out int mode))
                {

                    switch (mode)
                    {
                        case 1:

                            user.AddUser();

                            break;
                        case 2:

                            user.DisplayAllUsers();
                            break;

                        case 3:

                            user.DeleteUser();
                            break;

                        case 4:

                            award.AddAward();

                            break;
                        case 5:

                            award.DisplayAllAwards();
                            break;

                        case 6:
                            award.DeleteAward();
                            break;

                        case 7:
                            Guid selectUser = user.SelectedUser();
                            Guid selectAward = award.SelectedAward();
                            reward.RewardUser(selectUser, selectAward);
                            break;

                        case 8:
                            reward.DisplayAllRewards();
                            break;

                        default:

                            Console.WriteLine("К сожалению, такого дейcтвия нет");
                            break;
                    }
                }
                Console.ReadLine();
            }
        }
    }
}
*/