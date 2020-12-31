using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users
{
    public abstract class Doctors : User
    {
        public int PWZ { get; set; }

        public string Speciality { get; set; }

    }
}
