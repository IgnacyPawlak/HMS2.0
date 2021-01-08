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
    public class AdminViewModel: ViewModelBase
    {
        public AdminViewModel(MainViewModel mvm)
        {
            MVM = mvm;
            SelectedDate = DateTime.Today;
            MVM.SelectedUser = MVM.ListOfUsers.ElementAt(0);
        }
        public MainViewModel MVM { get; set; }

        DateTime _selectedDate ;
        public DateTime SelectedDate { get { return _selectedDate; } set { this.Set(nameof(SelectedDate), ref _selectedDate, value); } }

        string _wrongFormat;
        public string WrongFormat { get { return _wrongFormat; } set { this.Set(nameof(WrongFormat), ref _wrongFormat, value); } }

        public ICommand AddDateCommand => new RelayCommand(() => ExecuteAddDateCommand());

        public ICommand DeleteDateCommand => new RelayCommand(()=> ExecuteDeleteDateCommand());

        public ICommand AddNewUserCommand => new RelayCommand(() => ExecuteAddNewUserCommand());

        public ICommand DeleteUserCommand => new RelayCommand(() => ExecuteDeleteUserCommand());

        private void ExecuteAddDateCommand()
        {
            if (MVM.SelectedUser.GetType() != typeof(Admin))
            {
                string thisMonth = SelectedDate.Month.ToString();
                int dutiesThisMonth = 0;
                foreach (DateTime date in MVM.SelectedUser.Calendar)
                {
                    if(date.Month.ToString()==thisMonth)
                    {
                        dutiesThisMonth++;
                    }
                }
                if (dutiesThisMonth < 10)
                {
                    if (MVM.SelectedUser.Calendar.Contains(SelectedDate.AddDays(-1)) || MVM.SelectedUser.Calendar.Contains(SelectedDate.AddDays(1))
                || MVM.SelectedUser.Calendar.Contains(SelectedDate))
                    {
                        WrongFormat = "Niestety pracownicy muszą mieć co najmniej 24h między dyżurami";
                    }
                    else if(SelectedDate<DateTime.Today)
                    {
                        WrongFormat = "Nie można dodawać dyżurów wstecz";
                    }
                    else if(MVM.SelectedUser.GetType()==typeof(Doctor))
                    {
                        if(MVM.SelectedUser.Speciality=="Neurolog")
                        {
                            if (MVM.NeurologistsCalendar.Contains(SelectedDate))
                            {
                                WrongFormat = "Tego dnia ma dyżur inny neurolog";
                            }
                            else
                            {
                                MVM.SelectedUser.Calendar.Add(SelectedDate);
                                MVM.NeurologistsCalendar.Add(SelectedDate);
                            }
                        }
                        else if (MVM.SelectedUser.Speciality == "Laryngolog")
                        {
                            if (MVM.LaryngologistsCalendar.Contains(SelectedDate))
                            {
                                WrongFormat = "Tego dnia ma dyżur inny laryngolog";
                            }
                            else
                            {
                                MVM.SelectedUser.Calendar.Add(SelectedDate);
                                MVM.LaryngologistsCalendar.Add(SelectedDate);
                            }
                        }
                        else if (MVM.SelectedUser.Speciality == "Urolog")
                        {
                            if (MVM.UrologistsCalendar.Contains(SelectedDate))
                            {
                                WrongFormat = "Tego dnia ma dyżur inny urolog";
                            }
                            else
                            {
                                MVM.SelectedUser.Calendar.Add(SelectedDate);
                                MVM.UrologistsCalendar.Add(SelectedDate);
                            }
                        }
                        else if (MVM.SelectedUser.Speciality == "Kardiolog")
                        {
                            if (MVM.CardiologistsCalendar.Contains(SelectedDate))
                            {
                                WrongFormat = "Tego dnia ma dyżur inny kardiolog";
                            }
                            else
                            {
                                MVM.SelectedUser.Calendar.Add(SelectedDate);
                                MVM.CardiologistsCalendar.Add(SelectedDate);
                            }
                        }
                    }
                    else
                    {
                        MVM.SelectedUser.Calendar.Add(SelectedDate);
                        WrongFormat = "";
                    }
                }
                else WrongFormat = "Pracownik nie może mieć więcej niż 10 dyżurów w miesiącu";
                
            }
            else WrongFormat = "Administratorzy nie mają dyżurów";            
        }

        private void ExecuteDeleteDateCommand()
        {
            if (MVM.SelectedUser.GetType() != typeof(Admin))
                MVM.SelectedUser.Calendar.RemoveAt(MVM.SelectedDateIndex);
        }

        private void ExecuteAddNewUserCommand()
        {
            MVM.SelectedViewModel = new AddNewUserViewModel(MVM);
        }

        private void ExecuteDeleteUserCommand()
        {
            if (MVM.SelectedUser.GetType() == typeof(Doctor)) MVM.ListOfDoctors.Remove(MVM.SelectedUser);
            if (MVM.SelectedUser.GetType() == typeof(Nurse)) MVM.ListOfNurses.Remove(MVM.SelectedUser);
            MVM.ListOfUsers.Remove(MVM.SelectedUser);

        }
    }
}
