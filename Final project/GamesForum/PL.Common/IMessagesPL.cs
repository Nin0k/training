using Entitiens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Common
{
    public interface IMessagesPL
    {
        IEnumerable<Message> GetMassagesByIdTopic(Guid idTopic);
        Message GetMessageByID(Guid id);
        bool EditReputationMessang(Guid idMessage, string action);
    }
}
