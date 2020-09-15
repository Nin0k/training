using BLL.Common;
using DAL.Common;
using DAL.Dependencies;
using Entitiens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RewardBLL : IRewardBLL
    {
         UsersBLL user = new UsersBLL();
         AwardsBLL award = new AwardsBLL();
        // List<Awards> awardsList = new List<Awards>();

        private IRewardDAL _rewardDAL;
        public RewardBLL()
        {
            _rewardDAL = DependenciesDAL.RewardDAL;
        }

        public IEnumerable<Rewards> GetAllRewards()
        {
            return _rewardDAL.GetAllRewards();
        }

        public bool RewardUser(Guid userID, Guid awardID)
        {
            try
            {
                var foundUser = user.GetUserByID(userID);
                var foundAward = award.GetAwardByID(awardID);

                //new Rewards(foundUser, foundAward);
                List<Awards> awardsList = new List<Awards>();
                awardsList.Add(foundAward);
                _rewardDAL.SaveRaward(new Rewards(foundUser, awardsList));
                return true;
            }
             catch
            {
                    // TODO: checking more exceptions
                return false;
            }
            
        }
    }
}
