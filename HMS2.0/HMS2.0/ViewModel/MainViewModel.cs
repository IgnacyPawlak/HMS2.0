using GalaSoft.MvvmLight;
using HMS2._0.Model;
using System.Collections.Generic;
using Users;

namespace HMS2._0.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _selectedViewModel;

        public ViewModelBase SelectedViewModel
        {
            get { return _selectedViewModel; }
            set { this.Set(nameof(SelectedViewModel), ref _selectedViewModel, value); }
        }

        List<IUsers> _users;
        public List<IUsers> Users { get { return _users; }set { this.Set(nameof(Users), ref _users, value); } }

    }
}