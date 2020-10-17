using BLL.Common;
using DAL.Common;
using Entitiens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Logic
{
    public class ForumsBLL : IForumsBLL
    {
        private IForumsDAL _forumsDAL;
        public IEnumerable<Forum> AllForums => _forumsDAL.GetAllForums();
    }
}
