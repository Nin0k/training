using BLL.Common;
using BLL.Dependencies;
using PL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks_7
{
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
    }
}
