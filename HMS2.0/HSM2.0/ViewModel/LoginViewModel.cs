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
        public ICommand CommandNameToChange => new RelayCommand(() => ExecuteCommand());
        string _username;
        public string Username { set { this.Set(nameof(Username), ref _username, value); } }
        string _password;
        public string Password { set { this.Set(nameof(Password), ref _password, value); } }
        private void ExecuteCommand()
        {
            foreach (var user in MVM.Users)
            {
                if (_username==user.Username&&_password==user.Password)
                {

                    MVM.SelectedViewModel = MVM.UVM;
                }
                else
                {

                }
            }
        }
    }
}
