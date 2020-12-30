using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSM2._0.ViewModel
{
    public class UserViewModel:ViewModelBase
    {
        public UserViewModel(MainViewModel mvm)
        {
            MVM = mvm;
        }
       public MainViewModel MVM { get; private set; }
    }
}
