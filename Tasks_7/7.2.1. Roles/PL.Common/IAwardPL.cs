using Entitiens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Common
{
    public interface IAwardPL
    {
        IEnumerable<Awards> DisplayAllAwards();
        bool AddAward(string title);
        bool DeleteAward(Guid id);
        Awards GetAwardByID(Guid id);
        bool EditAward(Guid id, string title);
    }
}
