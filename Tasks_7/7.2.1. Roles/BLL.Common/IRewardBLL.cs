using Entitiens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Common
{
    public interface IRewardBLL
    {
        bool RewardUser(Guid userID, Guid awardID);
        IEnumerable<Rewards> GetAllRewards();
        List<Users> GetUsersWithCurrentReward(Guid idAward);
        bool DeleteUserReward(Guid id);
        bool DeleteAwardReward(Guid id);
        bool DeleteReward(Guid idUser, Guid idAward);
        bool EditUser(Users user);
        bool EditAward(Awards newAward);
    }
}
