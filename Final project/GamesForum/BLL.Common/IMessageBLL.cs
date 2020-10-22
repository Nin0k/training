using Entitiens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Common
{
    public interface IMessageBLL
    {
        IEnumerable<Message> GetMassagesByIdTopic(Guid idTopic);
        Message GetMessageByID(Guid id);
        bool EditReputationMessang(Guid idMessage, string action);
        Guid CreateNewMessage(string textMessage, Guid idUser, Guid idTopic);
    }
}
