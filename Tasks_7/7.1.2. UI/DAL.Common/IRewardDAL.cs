using Entitiens;
using System.Collections.Generic;


namespace DAL.Common
{
    public interface IRewardDAL
    {
        void SaveRaward(Rewards reward);
        IEnumerable<Rewards> GetAllRewards();
    }
}
