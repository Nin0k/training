using BLL.Common;

namespace BLL.Dependencies
{
    public static class DependenciesBLL
    {
        private static IUserBLL _userBLL;
        private static IAwardBLL _awardBLL;
        private static IRewardBLL _rewardBLL;

        public static IUserBLL UserBLL => _userBLL ?? (_userBLL = new UsersBLL());
        public static IAwardBLL AwardBLL => _awardBLL ?? (_awardBLL = new AwardsBLL());
        public static IRewardBLL RewardBLL => _rewardBLL ?? (_rewardBLL = new RewardBLL());
    }
}
