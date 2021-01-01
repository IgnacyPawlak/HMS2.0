using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users
{
    public interface IUsers
    {
        string Name { get; }
        string Surname { get; }
        string Pesel { get; }
        string Username { get; }
        string Password { get; }
        string Position { get; set; }
        List<DateTime> Calendar { get; }
    }
}
