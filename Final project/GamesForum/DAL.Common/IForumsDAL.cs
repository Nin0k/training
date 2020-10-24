using Entitiens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Common
{
    public interface IForumsDAL
    {
        IEnumerable<Forum> GetAllForums();
        Forum GetForumByID(Guid idForum);
        Forum GetForumByName(string name);
    }
}
