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
        }
        public MainViewModel MVM { get; set; }
        public ICommand LogInCommand => new RelayCommand(() => ExecuteCommand());
        string _username;
        public string Username { set { this.Set(nameof(Username), ref _username, value); } }
        string _password;
        public string Password { set { this.Set(nameof(Password), ref _password, value); } }
        string _wrongUsernameOrPassword;
        public string WrongUsernameOrPassword
        {
            get { return _wrongUsernameOrPassword; }
            set { this.Set(nameof(WrongUsernameOrPassword), ref _wrongUsernameOrPassword, value); }
        }
        private void ExecuteCommand()
        {
            foreach (var user in MVM.Users)
            {
                if (_username==user.Username&&_password==user.Password)
                {
                    MVM.LoggedInUser = user;
                    if (user.GetType() != typeof(Admin))
                    {
                        MVM.Doctor.Calendar.Add(DateTime.Today);
                        MVM.Nurse.Calendar.Add(DateTime.Today);
                        MVM.SelectedViewModel = MVM.UVM;
                    }
                    else
                    {
                        MVM.Doctor.Calendar.Add(DateTime.Today);
                        MVM.Nurse.Calendar.Add(DateTime.Today);
                        MVM.SelectedViewModel = MVM.AVM;
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
