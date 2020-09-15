using PL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks_7;

namespace PL.Dependencies
{
    public static class DependenciesPL
    {
        private static IUserPL _userPL;
        public static IUserPL UserPL => _userPL ?? (_userPL = new ConsoleUserPL());
    }
}
