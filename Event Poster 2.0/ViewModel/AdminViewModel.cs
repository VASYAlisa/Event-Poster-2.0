using Event_Poster_2._0.Utilities;
using Event_Poster_2._0.ViewModel.AdminPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Event_Poster_2._0.ViewModel
{
    public class AdminViewModel: ViewModelBase
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(nameof(CurrentView)); }
        }

        public ICommand EventsCommand { get; set; }
        public ICommand CitiesCommand { get; set; }
        public ICommand CategoriesCommand { get; set; }
        public ICommand ReportsCommand { get; set; }

        private void Events(object obj) => CurrentView = new EventsViewModel();
        private void Categories(object obj) => CurrentView = new CategoriesViewModel();
        private void Cities(object obj) => CurrentView = new CitiesViewModel();
        private void Reports(object obj) => CurrentView = new ReportsViewModel();

        public AdminViewModel()
        {
            EventsCommand = new RelayCommand(Events);
            CategoriesCommand = new RelayCommand(Categories);
            CitiesCommand = new RelayCommand(Cities);
            ReportsCommand = new RelayCommand(Reports);

            CurrentView = new EventsViewModel();
        }
    }
}
