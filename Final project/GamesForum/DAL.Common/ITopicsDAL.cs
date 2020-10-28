using Entitiens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Common
{
    public interface ITopicsDAL
    {
        IEnumerable<Topic> GetAllByIdForum(Guid idForum);
        Topic GetTopicByID(Guid idTopic);
        void CreateNewTopic(Topic newTopic);
        void DeleteTopic(Guid idTopic);
    }
}
