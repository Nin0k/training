using BLL.Common;
using BLL.Dependencies;
using Entitiens;
using PL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PL.Web.Moduls
{
    public class WebForumsPL : IForumsPL
    {
        private IForumsBLL _bll;
        public WebForumsPL() => _bll = DependenciesBLL.ForumsBLL;
        public IEnumerable<Forum> DisplayAllForums() => _bll.AllForums;

    }
}