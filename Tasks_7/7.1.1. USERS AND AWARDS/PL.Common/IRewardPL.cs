using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Common
{
    public interface IRewardPL
    {
        bool RewardUser(Guid user, Guid award);
        void DisplayAllRewards();
    }
}
