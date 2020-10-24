using BLL.Common;
using DAL.Common;
using DAL.Dependencies;
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
        public ForumsBLL()
        {
            _forumsDAL = DependenciesDAL.ForumsDAL;
        }
        public IEnumerable<Forum> AllForums => _forumsDAL.GetAllForums();

        public Forum GetForumByID(Guid idForum) => _forumsDAL.GetForumByID(idForum);
        public Forum GetForumByName(string name) => _forumsDAL.GetForumByName(name);
    }
}
