using BLL.Common;
using DAL.Common;
using DAL.Dependencies;
using Entitiens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AwardsBLL : IAwardBLL
    {
        private IAwardDAL _awardDAL;
        public AwardsBLL()
        {
            _awardDAL = DependenciesDAL.AwardDAL;
        }

        public bool DeleteAward(Guid id)
        {
            try
            {
                // TODO: logging, send messages
                _awardDAL.DeleteAward(id);
                return true;
            }
            catch
            {
                // TODO: checking more exceptions
                return false;
            }
        }

        public IEnumerable<Awards> GetAllAwards()
        {
            return _awardDAL.GetAllAwards();
        }

        public Awards GetAwardByID(Guid id)
        {
            return _awardDAL.GetAwardByID(id);
        }

        public bool SaveAward(Awards award)
        {
            try
            {
                // TODO: logging, send messages
                _awardDAL.SaveAward(award);
                return true;
            }
            catch
            {
                // TODO: checking more exceptions
                return false;
            }
        }
    }
}
