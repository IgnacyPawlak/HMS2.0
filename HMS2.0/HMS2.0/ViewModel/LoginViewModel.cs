using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS2._0.ViewModel
{
    public class LoginViewModel:MainViewModel
    {
        public LoginViewModel(MainViewModel baseViewModel)
        {
            BaseViewModel = baseViewModel;
        }
        public MainViewModel BaseViewModel { get; private set; }
    }
}
