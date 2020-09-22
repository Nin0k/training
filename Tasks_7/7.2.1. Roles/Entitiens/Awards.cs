using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitiens
{
    public class Awards
    {
        public Guid IDAward { get; set; }

        public string Title { get; set; }

        protected Awards()
        {
            IDAward = Guid.NewGuid();
        }
        public Awards(string title) : this()
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
        }
    }
}
