using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HSM2._0.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Input;
using Users;

namespace HSM2._0.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        ViewModelBase _selectedViewModel;
        public ViewModelBase SelectedViewModel { get { return _selectedViewModel; } set { this.Set(nameof(SelectedViewModel), ref _selectedViewModel, value); } }

        LoginViewModel _lvm;
        public LoginViewModel LVM { get { return _lvm; } set { this.Set(nameof(LVM), ref _lvm, value); } }
        EditUserViewModel _euvm;
        public EditUserViewModel EUVM { get { return _euvm; } set { this.Set(nameof(EUVM), ref _euvm, value); } }

        List<IUsers> _users = new List<IUsers>();
        public List<IUsers> Users { get { return _users; } set { this.Set(nameof(Users), ref _users, value); } }

        Admin _admin = new Admin("admin", "admin", "admin", "admin", "admin");
        public Admin Admin { get { return _admin; } }

        IUsers _loggedInUser;
        public IUsers LoggedInUser { get { return _loggedInUser; } set { this.Set(nameof(LoggedInUser), ref _loggedInUser, value); } }

        ObservableCollection<IUsers> _listOfDoctors = new ObservableCollection<IUsers>();
        public ObservableCollection<IUsers> ListOfDoctors { get { return _listOfDoctors; } set { this.Set(nameof(ListOfDoctors), ref _listOfDoctors, value); } }

        ObservableCollection<IUsers> _listOfUsers = new ObservableCollection<IUsers>();
        public ObservableCollection<IUsers> ListOfUsers { get { return _listOfUsers; } set { this.Set(nameof(ListOfUsers), ref _listOfUsers, value); } }

        ObservableCollection<IUsers> _listOfNurses = new ObservableCollection<IUsers>();
        public ObservableCollection<IUsers> ListOfNurses { get { return _listOfNurses; } set { this.Set(nameof(ListOfNurses), ref _listOfNurses, value); } }

        IUsers _selectedUser;
        public IUsers SelectedUser { get { return _selectedUser; } set { this.Set(nameof(SelectedUser), ref _selectedUser, value); } }

        Doctor _selectedDoctor;
        public Doctor SelectedDoctor { get { return _selectedDoctor; } set { this.Set(nameof(SelectedDoctor), ref _selectedDoctor, value); } }

        IUsers _selectedNurse;
        public IUsers SelectedNurse { get { return _selectedNurse; } set { this.Set(nameof(SelectedNurse), ref _selectedNurse, value); } }

        int _selectedDateIndex;
        public int SelectedDateIndex { get { return _selectedDateIndex; } set { this.Set(nameof(SelectedDateIndex), ref _selectedDateIndex, value); } }

        List<DateTime> _cardiologistsCalendar = new List<DateTime>();
        public List<DateTime> CardiologistsCalendar { get { return _cardiologistsCalendar; } set { this.Set(nameof(CardiologistsCalendar), ref _cardiologistsCalendar, value); } }

        List<DateTime> _urologistsCalendar = new List<DateTime>();
        public List<DateTime> UrologistsCalendar { get { return _urologistsCalendar; } set { this.Set(nameof(UrologistsCalendar), ref _urologistsCalendar, value); } }

        List<DateTime> _laryngologistsCalendar = new List<DateTime>();
        public List<DateTime> LaryngologistsCalendar { get { return _laryngologistsCalendar; } set { this.Set(nameof(LaryngologistsCalendar),
            ref _laryngologistsCalendar, value); } }

        List<DateTime> _neurologistsCalendar = new List<DateTime>();
        public List<DateTime> NeurologistsCalendar { get { return _neurologistsCalendar; } set { this.Set(nameof(NeurologistsCalendar),
            ref _neurologistsCalendar, value); } }

        public ICommand ExitCommand => new RelayCommand(() => ExecuteExitCommand());

        private void ExecuteExitCommand()
        {
            Users = new List<IUsers>();
            foreach (var item in ListOfUsers)
            {
                if (!Users.Contains(item)) Users.Add(item);
            }
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream("lista.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                bf.Serialize(fs, Users);
            }
            App.Current.Shutdown();
        }

        public MainViewModel()
        {
            BinaryFormatter bf = new BinaryFormatter();
            string filePath = "lista.dat";
            if(File.Exists(filePath))
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    Users = (List<IUsers>)bf.Deserialize(fs);
                }
            }
            else
            {
                Users.Add(Admin);
            }
            LVM = new LoginViewModel(this);
            //EUVM = new EditUserViewModel(this);
            _selectedViewModel = LVM;
            foreach (IUsers user in Users)
            {
                int thisMonth = DateTime.Today.Month;
                foreach (DateTime date in user.Calendar)
                {
                    if (date.Month == thisMonth)
                    {
                        user.DutiesThisMonth.Add(date);
                    }
                }
                if (user.GetType() == typeof(Doctor))
                {
                    if(user.Speciality == "Kardiolog")
                    {
                        foreach (DateTime date in user.Calendar)
                        {
                            CardiologistsCalendar.Add(date);
                        }
                    }
                    else if (user.Speciality == "Laryngolog")
                    {
                        foreach (DateTime date in user.Calendar)
                        {
                            LaryngologistsCalendar.Add(date);
                        }
                    }
                    else if (user.Speciality == "Urolog")
                    {
                        foreach (DateTime date in user.Calendar)
                        {
                            UrologistsCalendar.Add(date);
                        }
                    }
                    else if (user.Speciality == "Neurolog")
                    {
                        foreach (DateTime date in user.Calendar)
                        {
                            NeurologistsCalendar.Add(date);
                        }
                    }

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