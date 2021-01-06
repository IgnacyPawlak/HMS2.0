using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HSM2._0.ViewModel
{
    public class UserViewModel:ViewModelBase
    {
        public UserViewModel(MainViewModel mvm)
        {
            MVM = mvm;            
        }
        public MainViewModel MVM { get; private set; }

        ObservableCollection<DateTime> _doctorsDutiesThisMonth = new ObservableCollection<DateTime>();
        public ObservableCollection<DateTime> DoctorsDutiesThisMonth
        {
            get { return _doctorsDutiesThisMonth; }
            set { this.Set(nameof(DoctorsDutiesThisMonth), ref _doctorsDutiesThisMonth, value); }
        }
        ObservableCollection<DateTime> _nursesDutiesThisMonth = new ObservableCollection<DateTime>();
        public ObservableCollection<DateTime> NursesDutiesThisMonth
        {
            get { return _nursesDutiesThisMonth; }
            set { this.Set(nameof(NursesDutiesThisMonth), ref _nursesDutiesThisMonth, value); }
        }

        public ICommand SelectedMethod => new RelayCommand(() => ExecuteMethod());
        private void ExecuteMethod()
        {

        }
    }
}
