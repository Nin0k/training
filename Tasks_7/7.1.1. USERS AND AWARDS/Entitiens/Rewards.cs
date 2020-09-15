using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitiens
{
    public class Rewards
    {
        public Users User { get; set; }
        //public Awards Award { get; set; }
        public List<Awards> Award { get; set; }

        public Rewards(Users user, List<Awards> award) 
        {
            User = user ?? throw new ArgumentNullException(nameof(user));
            Award = award ?? throw new ArgumentNullException(nameof(award));
            //Award.Add(award ?? throw new ArgumentNullException(nameof(award)));
        }
        
    }
}
