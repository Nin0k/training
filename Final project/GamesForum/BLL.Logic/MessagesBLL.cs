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
   public class MessagesBLL : IMessageBLL
    {
        private IMessageDAL _messageDAL;
        public MessagesBLL()
        {
            _messageDAL = DependenciesDAL.MessageDAL;
        }

        public IEnumerable<Message> GetMassagesByIdTopic(Guid idTopic) => _messageDAL.GetMassagesByIdTopic(idTopic);

        public Message GetMessageByID(Guid id) => _messageDAL.GetMessageByID(id);

        public bool EditReputationMessang(Guid idMessage, string action)
        {
            try
            {
                Message message = GetMessageByID(idMessage);
                int reputation = message.Reputation;

                if (action == "+")
                {
                    reputation++;
                }
                else if (action == "-")
                {
                    reputation--;
                }
                message.Reputation = reputation;
                _messageDAL.EditMessang(message);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Guid CreateNewMessage(string textMessage, Guid idUser, Guid idTopic)
        {
            Message messange = new Message(textMessage, idUser, idTopic);
            _messageDAL.CreateNewMessage(messange);
            return messange.IDMessage;
        }
        public bool DeleteMessage(Guid idMessage)
        {
            try
            {
                _messageDAL.DeleteMessage(idMessage);
                return true;
            }
            catch 
            {

                return false;
            }
        }
    }
}
