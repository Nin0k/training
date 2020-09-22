using Entitiens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Common
{
   public interface IAwardDAL
    {
        void SaveAward(Awards award);
        void DeleteAward(Guid id);
        IEnumerable<Awards> GetAllAwards();
        Awards GetAwardByID(Guid id);
    }
}
