using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users
{
    [Serializable]
    public class Admin : IUsers
    {
        public string Name { get; }

        public string Surname { get; }

        public string Pesel { get; }

        public string Username { get; }

        public string Password { get; }

        public List<DateTime> Calendar { get; }

        public Admin(string name, string surname, string pesel, string username, string password)
        {
            Name = name;
            Surname = surname;
            Pesel = pesel;
            Username = username;
            Password = password;
        }
    }
}
