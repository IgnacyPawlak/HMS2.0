using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users
{
    [Serializable]
    public abstract class Doctors : User
    {
        public int PWZ { get; set; }
    }
}
