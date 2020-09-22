using DAL.Common;
using DAL.Json;

namespace DAL.Dependencies
{
    public static class DependenciesDAL
    {
        private static IUserDAL _userDAL;
        private static IAwardDAL _awardDAL;
        private static IRewardDAL _rewardDAL;
        public static IUserDAL UserDAL => _userDAL ?? (_userDAL = new JsonUsersDAL());
        public static IAwardDAL AwardDAL => _awardDAL ?? (_awardDAL = new JsonAwardsDAL());
        public static IRewardDAL RewardDAL => _rewardDAL ?? (_rewardDAL = new JsonRewardDAL());
    }
}
