using BLL.Common;
using DAL.Common;
using DAL.Dependencies;
using Entitiens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Logic
{
    public class TopicsBLL : ITopicsBLL
    {
        private ITopicsDAL _topicsDAL;
        public TopicsBLL()
        {
            _topicsDAL = DependenciesDAL.TopicsDAL;
        }
        public IEnumerable<Topic> GetAllByIdForum(Guid idForum) => _topicsDAL.GetAllByIdForum(idForum);

        public Topic GetTopicByID(Guid idTopic) => _topicsDAL.GetTopicByID(idTopic);
        public Guid CreateNewTopic(string name, Guid idForum, bool importand)
        {
            Topic newTopic = new Topic(name, idForum, importand);
            _topicsDAL.CreateNewTopic(newTopic);
            return newTopic.IDTopic;
        }
        public bool DeleteTopic(Guid idTopic) 
        {
            try
            {
                _topicsDAL.DeleteTopic(idTopic);
                return true;
            }
            catch 
            {

                return false;
            }
        }
    }
}
