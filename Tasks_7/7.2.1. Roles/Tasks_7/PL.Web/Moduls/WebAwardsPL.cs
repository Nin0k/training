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
    public class WebAwardsPL : IAwardPL
    {
        private IAwardBLL _bll;
        public WebAwardsPL() => _bll = DependenciesBLL.AwardBLL;
        public bool AddAward(string title) => _bll.SaveAward(new Awards(title));
        public bool DeleteAward(Guid id) => _bll.DeleteAward(id);
        public IEnumerable<Awards> DisplayAllAwards() => _bll.GetAllAwards();
        public Awards GetAwardByID(Guid id) => _bll.GetAwardByID(id);
        public bool EditAward(Guid id, string title) => _bll.EditAward(id, title);
    }
}