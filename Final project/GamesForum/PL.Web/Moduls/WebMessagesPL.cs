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
    public class WebMessagesPL : IMessagesPL
    {
        private IMessageBLL _messagesBLL;
        public WebMessagesPL()
        {
            _messagesBLL = DependenciesBLL.MessagesBLL;
        }
        public IEnumerable<Message> GetMassagesByIdTopic(Guid idTopic) => _messagesBLL.GetMassagesByIdTopic(idTopic);

        public Message GetMessageByID(Guid id) => _messagesBLL.GetMessageByID(id);

        public bool EditReputationMessang(Guid idMessage, string action) => _messagesBLL.EditReputationMessang(idMessage, action);
    }
}