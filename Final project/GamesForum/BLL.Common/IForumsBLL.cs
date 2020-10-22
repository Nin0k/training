using Entitiens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Common
{
    public interface IForumsBLL
    {
        IEnumerable<Forum> AllForums { get; }
        Forum GetForumByID(Guid idForum);
    }
}
