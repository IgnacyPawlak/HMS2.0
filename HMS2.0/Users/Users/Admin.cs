using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users
{
    [Serializable]
    public class Admin : User
    {
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
