using BLL.Common;
using BLL.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dependencies
{
    public class DependenciesBLL
    {
        private static IForumsBLL _forumsBLL;
        private static ITopicsBLL _topicsBLL;
        private static IMessageBLL _messagesBLL;
        private static IUsersBLL _usersBLL;

        public static IForumsBLL ForumsBLL => _forumsBLL ?? (_forumsBLL = new ForumsBLL());
        public static ITopicsBLL TopicsBLL => _topicsBLL ?? (_topicsBLL = new TopicsBLL());
        public static IMessageBLL MessagesBLL => _messagesBLL ?? (_messagesBLL = new MessagesBLL());
        public static IUsersBLL UsersBLL => _usersBLL ?? (_usersBLL = new UsersBLL());
    }
}
