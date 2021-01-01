using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HSM2._0.ViewModel
{
    public class AdminViewModel: ViewModelBase
    {
        public AdminViewModel(MainViewModel mvm)
        {
            MVM = mvm;
        }
        public MainViewModel MVM { get; set; }
        public ICommand DeleteDateCommand => new RelayCommand(()=> ExecuteDeleteDateCommand());

        private void ExecuteDeleteDateCommand()
        {
            MVM.SelectedUser.Calendar.RemoveAt(MVM.SelectedDateIndex);
        }
    }
}
