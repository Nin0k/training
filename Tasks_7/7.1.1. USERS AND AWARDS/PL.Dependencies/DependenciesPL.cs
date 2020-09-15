using PL.Common;
using Tasks_7;

namespace PL.Dependencies
{
    public static class DependenciesPL
    {
        private static IUserPL _userPL;
        public static IUserPL UserPL => _userPL ?? (_userPL = new ConsoleUserPL());
    }
}
