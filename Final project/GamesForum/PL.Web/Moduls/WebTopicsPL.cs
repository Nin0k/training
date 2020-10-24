using BLL.Common;
using BLL.Dependencies;
using Entitiens;
using PL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PL.Web
{
    public class WebTopicsPL : ITopicsPL
    {
        private ITopicsBLL _topicsBLL;
        public WebTopicsPL()
        {
            _topicsBLL = DependenciesBLL.TopicsBLL;
        }
        public IEnumerable<Topic> GetAllByIdForum(Guid idForum) => _topicsBLL.GetAllByIdForum(idForum);
        public Topic GetTopicByID(Guid idTopic) => _topicsBLL.GetTopicByID(idTopic);
        public Guid CreateNewTopic(string name, Guid idForum, bool importand) => _topicsBLL.CreateNewTopic(name, idForum, importand);
    }
}