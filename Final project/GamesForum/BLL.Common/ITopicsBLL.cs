using Entitiens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Common
{
    public interface ITopicsBLL
    {
        IEnumerable<Topic> GetAllByIdForum(Guid idForum);
        Topic GetTopicByID(Guid idTopic);
    }
}
