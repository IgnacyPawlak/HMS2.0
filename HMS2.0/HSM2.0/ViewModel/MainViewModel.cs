using GalaSoft.MvvmLight;
using HSM2._0.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        AdminViewModel _avm;
        public AdminViewModel AVM { get { return _avm; } set { this.Set(nameof(AVM), ref _avm, value); } }
        List<IUsers> _users = new List<IUsers>();
        public List<IUsers> Users { get { return _users; } set { this.Set(nameof(Users), ref _users, value); } }
        Admin _admin = new Admin("admin", "admin", "admin", "admin", "admin");
        Doctor _doctor = new Doctor("Jan", "Kowalski", "99999999999", "jan", "kowalski", 123, "Laryngolog");
        Nurse _nurse = new Nurse("Anna", "Kowalska", "99999999999", "anna", "kowalska");
        public Nurse Nurse { get { return _nurse; } }
        public Doctor Doctor { get { return _doctor; } }
        public Admin Admin { get { return _admin; } }
        IUsers _loggedInUser;
        public IUsers LoggedInUser { get { return _loggedInUser; } set { this.Set(nameof(LoggedInUser), ref _loggedInUser, value); } }
        ObservableCollection<IUsers> _listOfDoctors = new ObservableCollection<IUsers>();
        public ObservableCollection<IUsers> ListOfDoctors { get { return _listOfDoctors; } set { this.Set(nameof(ListOfDoctors), ref _listOfDoctors, value); } }
        ObservableCollection<IUsers> _listOfUsers = new ObservableCollection<IUsers>();
        public ObservableCollection<IUsers> ListOfUsers { get { return _listOfUsers; } set { this.Set(nameof(ListOfUsers), ref _listOfUsers, value); } }
        ObservableCollection<IUsers> _listOfNurses = new ObservableCollection<IUsers>();
        public ObservableCollection<IUsers> ListOfNurses { get { return _listOfNurses; } set { this.Set(nameof(ListOfNurses), ref _listOfNurses, value); } }
        User _selectedUser;
        public User SelectedUser { get { return _selectedUser; } set { this.Set(nameof(SelectedUser), ref _selectedUser, value); } }
        User _selectedDoctor;
        public User SelectedDoctor { get { return _selectedDoctor; } set { this.Set(nameof(SelectedDoctor), ref _selectedDoctor, value); } }
        User _selectedNurse;
        public User SelectedNurse { get { return _selectedNurse; } set { this.Set(nameof(SelectedNurse), ref _selectedNurse, value); } }
        int _selectedDateIndex;
        public int SelectedDateIndex { get { return _selectedDateIndex; } set { this.Set(nameof(SelectedDateIndex), ref _selectedDateIndex, value); } }
        public MainViewModel()
        {
            UVM = new UserViewModel(this);
            LVM = new LoginViewModel(this);
            AVM = new AdminViewModel(this);
            _selectedViewModel = LVM;
            Users.Add(Admin);
            Users.Add(Doctor);
            Users.Add(Nurse);
            foreach (IUsers user in Users)
            {
                if (user.GetType() == typeof(Doctor))
                {
                    ListOfDoctors.Add(user);
                    ListOfUsers.Add(user);
                }
                else if (user.GetType() == typeof(Nurse))
                {
                    ListOfNurses.Add(user);
                    ListOfUsers.Add(user);
                }
                else ListOfUsers.Add(user);
            }
        }
    }
}