using BLL.Common;
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
        public bool AddAward(string title)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAward(Guid id)
        {
            return _bll.DeleteAward(id);
        }

        public void DisplayAllAwards()
        {
            throw new NotImplementedException();
        }

        public Guid SelectedAward()
        {
            throw new NotImplementedException();
        }
    }
}