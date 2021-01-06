using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users
{
    [Serializable]
    public abstract class User : IUsers
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Pesel { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Position { get; set; }

        public ObservableCollection<DateTime> Calendar { get; set; } = new ObservableCollection<DateTime>();

        public string Speciality { get; set; }

        public ObservableCollection<DateTime> DutiesThisMonth { get; set; } = new ObservableCollection<DateTime>();
    }
}
