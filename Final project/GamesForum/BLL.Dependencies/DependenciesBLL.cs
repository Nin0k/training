using BLL.Common;
using BLL.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dependencies
{
    public class DependenciesBLL
    {
        private static IForumsBLL _forumsBLL;

        public static IForumsBLL ForumsBLL => _forumsBLL ?? (_forumsBLL = new ForumsBLL());
    }
}
