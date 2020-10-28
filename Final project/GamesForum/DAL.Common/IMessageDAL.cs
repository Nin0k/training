using Entitiens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Common
{
    public interface IMessageDAL
    {
        IEnumerable<Message> GetMassagesByIdTopic(Guid idTopic);
        Message GetMessageByID(Guid id);
        void EditMessang(Message messange);
        void CreateNewMessage(Message messange);
        void DeleteMessage(Guid idMessage);
    }
}
