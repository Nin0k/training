using Entitiens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Common
{
    public interface ITopicsPL
    {
        IEnumerable<Topic> GetAllByIdForum(Guid idForum);
        Topic GetTopicByID(Guid idTopic);
        Guid CreateNewTopic(string name, Guid idForum, bool importand);
    }
}
