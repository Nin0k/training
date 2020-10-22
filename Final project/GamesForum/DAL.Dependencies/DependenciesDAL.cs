using DAL.Common;
using DAL.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Dependencies
{
    public class DependenciesDAL
    {
        private static IForumsDAL _forumDAL;
        private static ITopicsDAL _topicDAL;
        private static IMessageDAL _messageDAL;
        private static IUsersDAL _usersDAL;

        public static IForumsDAL ForumsDAL => _forumDAL ?? (_forumDAL = new SQLForumsDAL());
        public static ITopicsDAL TopicsDAL => _topicDAL ?? (_topicDAL = new SQLTopicsDAL());
        public static IMessageDAL MessageDAL => _messageDAL ?? (_messageDAL = new SQLMessageDAL());
        public static IUsersDAL UsersDAL => _usersDAL ?? (_usersDAL = new SQLUsersDAL());
    }
}
