using Entitiens;
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
        IEnumerable<Rewards> AllRewards();
        List<Users> GetUsersWithCurrentReward(Guid idAward);
        bool DeleteUserReward(Guid user);
        bool DeleteAwardReward(Guid award);
        bool DeleteReward(Guid idUser, Guid idAward);
        bool EditUser(Users newUser);
        bool EditAward(Awards newAward);
    }
}
