using BLL.Common;
using BLL.Dependencies;
using Entitiens;
using PL.Common;
using System;


namespace Tasks_7
{/*
    public class ConsoleRewardPL : IRewardPL
    {
        private IRewardBLL _bll;

        public ConsoleRewardPL()
        {
            _bll = DependenciesBLL.RewardBLL;
        }
        public bool RewardUser(Guid user, Guid award)
        {
            return _bll.RewardUser(user, award);
           
        }

        public void DisplayAllRewards()
        {
            var rewards = _bll.GetAllRewards();

            Console.WriteLine("Награжденные пользователи:" + Environment.NewLine);

            foreach (Rewards item in rewards)
            {
                Console.WriteLine(string.Format("Имя:{0}, Дата рождения:{1}, Возраст:{2}",
                    item.User.Name, item.User.DateOfBirth, item.User.Age));
                Console.WriteLine("Награды:");
                int number = 1;
                foreach (Awards j in item.Award)
                {
                    Console.WriteLine(string.Format("{0}) {1}", number++, j.Title));
                    
                }
                Console.WriteLine(Environment.NewLine);
            }
        }
    }*/
}
