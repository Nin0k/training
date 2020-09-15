using System;

namespace Entitiens
{
    public class Users
    {
        public Guid ID { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Age { get; set; }

        protected Users()
        {
            ID = Guid.NewGuid();
        }

        public Users(string name, DateTime birthday) : this()
        {
            
            Name = name ?? throw new ArgumentNullException(nameof(name));

            if(birthday != null)
            {
                DateOfBirth = birthday;
                DateTime DateNow = DateTime.Now;
                Age = DateNow.Year - DateOfBirth.Year;
            }
        }
    }
}
