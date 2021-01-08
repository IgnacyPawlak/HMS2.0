using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Users;

namespace HSM2._0.ViewModel
{
    public class LoginViewModel:ViewModelBase
    {
        public LoginViewModel(MainViewModel mvm)
        {
            MVM = mvm;
            Username = "Login";
            Password = "Hasło";
        }
        public MainViewModel MVM { get; set; }
        public ICommand LogInCommand => new RelayCommand(() => ExecuteCommand());
        string _username;
        public string Username { get { return _username; } set { this.Set(nameof(Username), ref _username, value); } }
        string _password;
        public string Password { get { return _password; } set { this.Set(nameof(Password), ref _password, value); } }
        string _wrongUsernameOrPassword;
        public string WrongUsernameOrPassword
        {
            get { return _wrongUsernameOrPassword; }
            set { this.Set(nameof(WrongUsernameOrPassword), ref _wrongUsernameOrPassword, value); }
        }
        private void ExecuteCommand()
        {
            foreach (var user in MVM.ListOfUsers)
            {
                if (_username==user.Username&&_password==user.Password)
                {
                    MVM.LoggedInUser = user;
                    if (user.GetType() != typeof(Admin))
                    {
                        MVM.SelectedViewModel = new UserViewModel(MVM);
                    }
                    else
                    {
                        MVM.SelectedViewModel = new AdminViewModel(MVM);
                    }
                }
                else
                {
                    WrongUsernameOrPassword = "Błędna nazwa użytkownika lub hasło";
                }
            }
        }
    }
}
