using GalaSoft.MvvmLight;
using HSM2._0.Model;
using System.Collections.Generic;
using Users;

namespace HSM2._0.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        ViewModelBase _selectedViewModel;
        public ViewModelBase SelectedViewModel { get { return _selectedViewModel; } set { this.Set(nameof(SelectedViewModel), ref _selectedViewModel, value); } }
        UserViewModel _uvm;
        public UserViewModel UVM { get { return _uvm; } set { this.Set(nameof(UVM), ref _uvm, value); } }
        LoginViewModel _lvm;
        public LoginViewModel LVM { get { return _lvm; } set { this.Set(nameof(LVM), ref _lvm, value); } }
        List<IUsers> _users = new List<IUsers>();
        public List<IUsers> Users { get { return _users; } set { this.Set(nameof(Users), ref _users, value); } }
        Admin _admin = new Admin("admin", "admin", "admin", "admin", "admin");
        public Admin Admin { get { return _admin; } }
        public MainViewModel()
        {
            UVM = new UserViewModel(this);
            LVM = new LoginViewModel(this);
            _selectedViewModel = LVM;
            Users.Add(Admin);
        }
    }
}