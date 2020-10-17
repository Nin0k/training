using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitiens
{
    public class Topic
    {
        public Guid IDTopic { get; set; }

        public string Name { get; set; }

        public Guid IDForum { get; set; }

        public bool Importand { get; set; }

        protected Topic()
        {
            IDTopic = Guid.NewGuid();
        }

        public Topic(string name, Guid idForum, bool importand) : this()
        {

            Name = name ?? throw new ArgumentNullException(nameof(name));

            Importand = importand;

            if (idForum != null)
            {
                IDForum = idForum;
            }

        }
    }
}
