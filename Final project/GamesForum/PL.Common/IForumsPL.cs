using Entitiens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Common
{
    public interface IForumsPL
    {
        IEnumerable<Forum> DisplayAllForums();
        Forum GetForumByID(Guid idForum);
    }
}
