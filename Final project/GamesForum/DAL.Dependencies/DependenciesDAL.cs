using DAL.Common;
using DAL.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Dependencies
{
    public class DependenciesDAL
    {
        private static IForumsDAL _forumDAL;

        public static IForumsDAL RewardDAL => _forumDAL ?? (_forumDAL = new SQLForumsDAL());

    }
}
