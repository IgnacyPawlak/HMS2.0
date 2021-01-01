using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users
{
    [Serializable]
    public class Doctor:Doctors
    {
        public Doctor(string name, string surname, string pesel, string username, string password, int pwz, string speciality):base()
        {
            Name = name;
            Surname = surname;
            Pesel = pesel;
            Username = username;
            Password = password;
            PWZ = pwz;
            Speciality = speciality;
            Position = "Lekarz";
        }
    }
}
