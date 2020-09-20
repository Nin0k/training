using Entitiens;
using System;
using System.Collections.Generic;


namespace DAL.Common
{
    public interface IRewardDAL
    {
        void SaveRaward(Rewards reward);
        IEnumerable<Rewards> GetAllRewards();
        List<Users> GetUsersWithCurrentReward(Guid idAward);
        void DeleteUserReward(Guid IDUser);

        void DeleteAwardReward(Guid IDAward);
        void DeleteReward(Guid idUser, Guid idAward);
    }
}
