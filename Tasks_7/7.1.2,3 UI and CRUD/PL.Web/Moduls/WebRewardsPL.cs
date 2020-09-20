using BLL.Common;
using BLL.Dependencies;
using Entitiens;
using PL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PL.Web
{
    public class WebRewardsPL : IRewardPL
    {
        private IRewardBLL _bll;
        public WebRewardsPL() => _bll = DependenciesBLL.RewardBLL;
        public IEnumerable<Rewards> AllRewards() => _bll.GetAllRewards();

        public List<Users> GetUsersWithCurrentReward(Guid idAward) => _bll.GetUsersWithCurrentReward(idAward);
        public bool RewardUser(Guid user, Guid award) => _bll.RewardUser(user, award);

        public bool DeleteUserReward(Guid user) => _bll.DeleteUserReward(user);
        public bool DeleteAwardReward(Guid award) => _bll.DeleteAwardReward(award);
        public bool DeleteReward(Guid idUser, Guid idAward) => _bll.DeleteReward(idUser, idAward);
        public bool EditUser(Users newUser) => _bll.EditUser(newUser);
        public bool EditAward(Awards newAward) => _bll.EditAward(newAward);

    }
}