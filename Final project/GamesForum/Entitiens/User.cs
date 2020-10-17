using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitiens
{
    public class User
    {
        public Guid IDUser { get; set; }

        public string Nickname { get; set; }

        public DateTime DateRegistration { get; set; }

        public int Reputation { get; set; }

        public bool Admin { get; set; }

        protected User()
        {
            IDUser = Guid.NewGuid();

        }

        public User(string name, bool admin) : this()
        {

            Nickname = name ?? throw new ArgumentNullException(nameof(name));

            Admin = admin;

            Reputation = 0;

            DateRegistration = DateTime.Now;
        }
    }
}
