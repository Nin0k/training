using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitiens
{
    public class Forum
    {
        public Guid IDForum { get; set; }

        public string Name { get; set; }

        protected Forum()
        {
            IDForum = Guid.NewGuid();
        }

        public Forum(string name) : this()
        {

            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
