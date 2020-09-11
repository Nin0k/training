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

        private IRewardDAL _rewardDAL;
        public RewardBLL()
        {
            _rewardDAL = DependenciesDAL.RewardDAL;
        }
        public bool RewardUser(Guid userID, Guid awardID)
        {
            try
            {
                Users foundUser = user.GetUserByID(userID);
                Awards foundAward = award.GetAwardByID(awardID);
                _rewardDAL.SaveRaward(foundUser, foundAward);
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
