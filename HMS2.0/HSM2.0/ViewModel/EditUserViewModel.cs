using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Users;

namespace HSM2._0.ViewModel
{
    public class EditUserViewModel:ViewModelBase
    {
        public EditUserViewModel(MainViewModel mvm)
        {
            Name = mvm.SelectedUser.Name;
            Surname = mvm.SelectedUser.Surname;
            Username = mvm.SelectedUser.Username;
            Password = mvm.SelectedUser.Password;
            Pesel = mvm.SelectedUser.Pesel;
            Positions = new ObservableCollection<string>
            {
                "Administrator",
                "Lekarz",
                "Pielęgniarka"
            };
            Specialities = new ObservableCollection<string>
            {
                "Kardiolog",
                "Laryngolog",
                "Urolog",
                "Neurolog",
                "Brak specializacji"
            };
            if (mvm.SelectedUser.GetType()==typeof(Doctor))
            {
                mvm.SelectedDoctor = (Doctor)mvm.SelectedUser;
                PWZ = mvm.SelectedDoctor.PWZ;
                DoctorSelected = true;
                SelectedPostion = Positions[1];
                StringPWZ = PWZ.ToString();
                Speciality = mvm.SelectedDoctor.Speciality;
            }
            if(mvm.SelectedUser.GetType()!=typeof(Doctor))
            {
                DoctorSelected = false;
                StringPWZ = "Numer PWZ";
                Speciality = null;
                if (mvm.SelectedUser.GetType() == typeof(Admin)) SelectedPostion = Positions[0];
                if (mvm.SelectedUser.GetType() == typeof(Nurse)) SelectedPostion = Positions[2];
            }
            
            MVM = mvm;
        }

        MainViewModel MVM { get; set; }

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
        public int PWZ { get { return _pwz; } set { this.Set(nameof(PWZ), ref _pwz, value); } }

        string _stringpwz;
        public string StringPWZ { get { return _stringpwz; } set { this.Set(nameof(StringPWZ), ref _stringpwz, value); } }

        string _speciality;
        public string Speciality { get { return _speciality; } set { this.Set(nameof(Speciality), ref _speciality, value); } }

        ObservableCollection<string> _positions = new ObservableCollection<string>();
        public ObservableCollection<string> Positions { get { return _positions; } set { this.Set(nameof(Positions), ref _positions, value); } }

        ObservableCollection<string> _specialities;
        public ObservableCollection<string> Specialities { get { return _specialities; } set { this.Set(nameof(Specialities), ref _specialities, value); } }

        int _selectedindex;
        public int SelectedIndex { get { return _selectedindex; } set { this.Set(nameof(SelectedIndex), ref _selectedindex, value); } }

        int _selectedIndexSpecialities;
        public int SelectedIndexSpecialities { get { return _selectedIndexSpecialities; } set { this.Set(nameof(SelectedIndexSpecialities), ref _selectedIndexSpecialities, value); } }

        string _selectedPosition;
        public string SelectedPostion { get { return _selectedPosition; } set { this.Set(nameof(SelectedPostion), ref _selectedPosition, value); } }

        bool _doctorSelected = false;
        public bool DoctorSelected { get { return _doctorSelected; } set { this.Set(nameof(DoctorSelected), ref _doctorSelected, value); } }

        public ICommand SelectionChangedCommand => new RelayCommand(() => ExecuteSelectionChangedCommand());

        private void ExecuteSelectionChangedCommand()
        {
            if (SelectedIndex == Positions.IndexOf("Lekarz")) DoctorSelected = true;
            else DoctorSelected = false;
        }

        public ICommand SaveCommand => new RelayCommand(() => ExecuteSaveCommand());

        private void ExecuteSaveCommand()
        {
            Regex regex = new Regex("[0-9]{11}");
            if (regex.IsMatch(Pesel))
            {
                if (SelectedIndex == 1)
                {
                    if (int.TryParse(StringPWZ, out int a))
                    {
                        PWZ = int.Parse(StringPWZ);
                        if (MVM.SelectedUser.GetType() == typeof(Doctor))
                        {
                            MVM.ListOfDoctors.Remove(MVM.SelectedUser);
                            MVM.ListOfUsers.Remove(MVM.SelectedUser);
                        }
                        else if (MVM.SelectedUser.GetType() == typeof(Admin))
                        {
                            MVM.ListOfUsers.Remove(MVM.SelectedUser);
                        }
                        else if (MVM.SelectedUser.GetType() == typeof(Nurse))
                        {
                            MVM.ListOfNurses.Remove(MVM.SelectedUser);
                            MVM.ListOfUsers.Remove(MVM.SelectedUser);
                        }
                        if (SelectedIndexSpecialities != 4)
                        {
                            Speciality = Specialities.ElementAt(SelectedIndexSpecialities);
                        }
                        else if(SelectedIndexSpecialities==-1||SelectedIndexSpecialities==4)
                        {
                            Speciality = "";
                        }
                        Doctor doctor = new Doctor(Name, Surname, Pesel, Username, Password, PWZ, Speciality);
                        MVM.ListOfDoctors.Add(doctor);
                        MVM.ListOfUsers.Add(doctor);
                        MVM.SelectedViewModel = new AdminViewModel(MVM);
                    }
                    else WrongFormat += "Błędny format numeru PWZ";
                }
                else if (SelectedIndex == 0)
                {
                    if (MVM.SelectedUser.GetType() == typeof(Doctor))
                    {
                        MVM.ListOfDoctors.Remove(MVM.SelectedUser);
                        MVM.ListOfUsers.Remove(MVM.SelectedUser);
                    }
                    else if (MVM.SelectedUser.GetType() == typeof(Admin))
                    {
                        MVM.ListOfUsers.Remove(MVM.SelectedUser);
                    }
                    else if (MVM.SelectedUser.GetType() == typeof(Nurse))
                    {
                        MVM.ListOfNurses.Remove(MVM.SelectedUser);
                        MVM.ListOfUsers.Remove(MVM.SelectedUser);
                    }
                    Admin admin = new Admin(Name, Surname, Pesel, Username, Password);
                    MVM.ListOfUsers.Add(admin);
                    MVM.SelectedViewModel = new AdminViewModel(MVM);
                }
                else if (SelectedIndex == 2)
                {
                    if (MVM.SelectedUser.GetType() == typeof(Doctor))
                    {
                        MVM.ListOfDoctors.Remove(MVM.SelectedUser);
                        MVM.ListOfUsers.Remove(MVM.SelectedUser);
                    }
                    else if (MVM.SelectedUser.GetType() == typeof(Admin))
                    {
                        MVM.ListOfUsers.Remove(MVM.SelectedUser);
                    }
                    else if (MVM.SelectedUser.GetType() == typeof(Nurse))
                    {
                        MVM.ListOfNurses.Remove(MVM.SelectedUser);
                        MVM.ListOfUsers.Remove(MVM.SelectedUser);
                    }
                    Nurse nurse = new Nurse(Name, Surname, Pesel, Username, Password);
                    MVM.ListOfUsers.Add(nurse);
                    MVM.ListOfNurses.Add(nurse);
                    MVM.SelectedViewModel = new AdminViewModel(MVM);
                }
                else if(SelectedIndex==-1)
                {
                    if (MVM.SelectedUser.GetType() == typeof(Doctor))
                    {
                        MVM.ListOfDoctors.Remove(MVM.SelectedUser);
                        MVM.ListOfUsers.Remove(MVM.SelectedUser);
                        if(SelectedIndexSpecialities!=-1&&SelectedIndex!=4)
                        {
                            Speciality = Specialities.ElementAt(SelectedIndexSpecialities);
                        }
                        else
                        {
                            Speciality = "";
                        }
                        Doctor doctor = new Doctor(Name, Surname, Pesel, Username, Password, PWZ, Speciality);
                        MVM.ListOfDoctors.Add(doctor);
                        MVM.ListOfUsers.Add(doctor);
                        MVM.SelectedViewModel = new AdminViewModel(MVM);
                    }
                    else if (MVM.SelectedUser.GetType() == typeof(Admin))
                    {
                        MVM.ListOfUsers.Remove(MVM.SelectedUser);
                        Admin admin = new Admin(Name, Surname, Pesel, Username, Password);
                        MVM.ListOfUsers.Add(admin);
                        MVM.SelectedViewModel = new AdminViewModel(MVM);
                    }
                    else if (MVM.SelectedUser.GetType() == typeof(Nurse))
                    {
                        MVM.ListOfNurses.Remove(MVM.SelectedUser);
                        MVM.ListOfUsers.Remove(MVM.SelectedUser);
                        Nurse nurse = new Nurse(Name, Surname, Pesel, Username, Password);
                        MVM.ListOfUsers.Add(nurse);
                        MVM.ListOfNurses.Add(nurse);
                        MVM.SelectedViewModel = new AdminViewModel(MVM);
                    }
                }
            }
            else WrongFormat += "Błędny format peselu. ";
        }

        string _wrongFormat = "";
        public string WrongFormat { get { return _wrongFormat; } set { this.Set(nameof(WrongFormat), ref _wrongFormat, value); } }

        public ICommand GoBackCommand => new RelayCommand(() => ExecuteGoBackCommand());

        private void ExecuteGoBackCommand()
        {
            MVM.SelectedViewModel = new AdminViewModel(MVM);
        }
    }
}
