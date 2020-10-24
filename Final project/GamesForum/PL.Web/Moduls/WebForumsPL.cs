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
    public class WebForumsPL : IForumsPL
    {
        private IForumsBLL _bll;
        public WebForumsPL() => _bll = DependenciesBLL.ForumsBLL;
        public IEnumerable<Forum> DisplayAllForums() => _bll.AllForums;
        public Forum GetForumByID(Guid idForum) => _bll.GetForumByID(idForum);
        public Forum GetForumByName(string name) => _bll.GetForumByName(name);

    }
}