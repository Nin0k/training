using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitiens
{
    public class Message
    {
        public Guid IDMessage { get; set; }

        public string Text { get; set; }

        public DateTime Date { get; set; }

        public Guid IDUser { get; set; }

        public int Reputation { get; set; }
        public Guid IDTopic { get; set; }

        protected Message()
        {
            IDMessage = Guid.NewGuid();
        }

        public Message(string text, Guid idUser, Guid idTopic) : this()
        {

            Text = text ?? throw new ArgumentNullException(nameof(text));

            Reputation = 0;
            Date = DateTime.Now;

            if (idUser != null && idTopic != null)
            {
                IDUser = idUser;
                IDTopic = idTopic;
            }

        }
    }
}
