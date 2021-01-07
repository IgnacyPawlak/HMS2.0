using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSM2._0.ViewModel
{
    public class AddNewUserViewModel:ViewModelBase
    {
        public AddNewUserViewModel(MainViewModel mvm)
        {
            MVM = mvm;
            Username = "Nazwa Użytkownika";
            Password = "Hasło";
            Name = "Imię";
            Surname = "Nazwisko";
            Pesel = "Pesel";
            Position = "Pozycja";
            Positions.Add("Administrator");
            Positions.Add("Lekarz");
            Positions.Add("Pielęgniarka");
        }
        public MainViewModel MVM { get; set; }

        string _name;
        public string Name { get { return _name; } set { this.Set(nameof(Name), ref _name, value); } }

        string _surname;
        public string Surname { get { return _surname; } set { this.Set(nameof(Surname), ref _surname, value); } }

        string _username;
        public string Username { get { return _username; } set { this.Set(nameof(Username), ref _username, value); } }

        string _password;
        public string Password { get { return _password; } set { this.Set(nameof(Password), ref _password, value); } }

        string _pesel;
        public string Pesel { get { return _pesel; } set { this.Set(nameof(Pesel), ref _pesel, value); } }

        int _pwz;
        public int PWZ {get { return _pwz; } set { this.Set(nameof(PWZ), ref _pwz, value); } }

        string _speciality;
        public string Speciality { get { return _speciality; } set { this.Set(nameof(Speciality), ref _speciality, value); } }

        string _position;
        public string Position { get { return _position; } set { this.Set(nameof(Position), ref _position, value); } }

        List<string> _positions = new List<string>();
        public List<string> Positions { get { return _positions; } set { this.Set(nameof(Positions), ref _positions, value); } }
    }
}
