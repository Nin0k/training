using BLL.Common;
using DAL.Common;
using DAL.Dependencies;
using Entitiens;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class RewardBLL : IRewardBLL
    {
        private UsersBLL user = new UsersBLL();
        private AwardsBLL award = new AwardsBLL();
        
        private IRewardDAL _rewardDAL;

        public RewardBLL()
        {
            _rewardDAL = DependenciesDAL.RewardDAL;
        }

        public bool DeleteUserReward(Guid id)
        {
            try
            {
                _rewardDAL.DeleteUserReward(id);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteAwardReward(Guid id)
        {
            try
            {
                _rewardDAL.DeleteAwardReward(id);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteReward(Guid idUser, Guid idAward)
        {
            try
            {
                _rewardDAL.DeleteReward(idUser, idAward);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Rewards> GetAllRewards() => _rewardDAL.GetAllRewards();
        public List<Users> GetUsersWithCurrentReward(Guid idAward) => _rewardDAL.GetUsersWithCurrentReward(idAward);
        public bool RewardUser(Guid userID, Guid awardID)
        {
            try
            {
                var foundUser = user.GetUserByID(userID);
                var foundAward = award.GetAwardByID(awardID);

                List<Awards> awardsList = new List<Awards>();
                awardsList.Add(foundAward);
                _rewardDAL.SaveRaward(new Rewards(foundUser, awardsList));
                return true;
            }
             catch
            {
                return false;
            }
        }

        public bool EditUser(Users newUser)
        {
            try
            {
                IEnumerable<Rewards> reward = GetAllRewards();
                List<Awards> awardsList = new List<Awards>();

                foreach (var item in reward)
                {
                    if(item.User.ID == newUser.ID)
                    {
                        foreach (var award in item.Award)
                        {
                            awardsList.Add(award);
                        }
                    }
                }
                _rewardDAL.DeleteUserReward(newUser.ID);
                _rewardDAL.SaveRaward(new Rewards(newUser, awardsList));
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool EditAward(Awards newAward)
        {
            try
            {
                _rewardDAL.EditAward(newAward);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
