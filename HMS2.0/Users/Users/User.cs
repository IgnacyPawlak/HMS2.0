using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users
{
    public abstract class User : IUsers
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Pesel { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Position { get; set; }

        public List<DateTime> Calendar { get; set; } = new List<DateTime>();
    }
}
