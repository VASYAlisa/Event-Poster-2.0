using Event_Poster_2._0.Model.DAL;
using Event_Poster_2._0.Model.DTOs;
using Event_Poster_2._0.Model.Repositories;

using Event_Poster_2._0.Utilities;
using Event_Poster_2._0.View.UserPages;
using Event_Poster_2._0.View.UserWindows;
using Event_Poster_2._0.View.ViewForAdmin;
using Event_Poster_2._0.ViewModel.CRUD;
using Event_Poster_2._0.ViewModel.UserWindows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Event_Poster_2._0.ViewModel.UserPages
{
    public class CatalogViewModel: ViewModelBase
    {
        private int _cityId;
        private DateTime _dateStart;
        private DateTime _dateEnd;
        private ObservableCollection<City> _allCities;
        private ObservableCollection<Category> _allCategories;
        private int _selectedCities;
        private int _selectedCategories;
        private ObservableCollection<Event> _events;


        public ObservableCollection<Event> Events
        {
            get { return _events; }
            set { _events = value; OnPropertyChanged(nameof(Events)); }
        }

        public int CityId
        {
            get { return _cityId; }
            set { _cityId = value; OnPropertyChanged(nameof(CityId)); }
        }

        public DateTime DateStart
        {
            get { return _dateStart; }
            set { _dateStart = value; OnPropertyChanged(nameof(DateStart)); }
        }

        public DateTime DateEnd
        {
            get { return _dateEnd; }
            set { _dateEnd = value; OnPropertyChanged(nameof(DateEnd)); }
        }

        public ObservableCollection<Category> AllCategories
        {
            get { return _allCategories; }
            set { _allCategories = value; OnPropertyChanged(nameof(AllCategories)); }
        }

        public ObservableCollection<City> AllCities
        {
            get { return _allCities; }
            set { _allCities = value; OnPropertyChanged(nameof(AllCities)); }
        }

        public int SelectedCategories
        {
            get { return _selectedCategories; }
            set { _selectedCategories = value; OnPropertyChanged(nameof(SelectedCategories)); }
        }

        public int SelectedCities
        {
            get { return _selectedCities; }
            set { _selectedCities = value; OnPropertyChanged(nameof(SelectedCities)); }
        }


        public ICommand SearchEventCommand { get; set; }
        public ICommand ResetEventCommand { get; set; }
        public ICommand ViewEventCommand { get; set; }

        public ICommand AddEventToWishListCommand { get; set; }

        private DbRepos context;
        private UserViewModel userViewModel;
        public CatalogViewModel(UserViewModel _userViewModel)
        {
            context= new DbRepos();
            DateStart = DateTime.Now;
            DateEnd = DateTime.Now.AddMonths(+1);

            Events = context.Events.GetList();
            AllCategories = context.Categories.GetList();
            AllCities = context.Cities.GetList();

            SearchEventCommand = new RelayCommand(SearchEvent);
            ResetEventCommand = new RelayCommand(ResetEvents);
            ViewEventCommand = new RelayCommand(ViewEvent);

            userViewModel = _userViewModel;
            AddEventToWishListCommand = new RelayCommand(AddEvent);
        }

        private void AddEvent(object obj)
        {
            if (obj is Event @event)
            {
                var exitEvent = userViewModel.Events.FirstOrDefault(e => e.Id == @event.Id);
                if (exitEvent != null)
                {
                    exitEvent.Price += @event.Price;
                }
                else userViewModel.Events.Add(@event);
            }
        }

        private void SearchEvent(object obj)
        {
            Events = new ObservableCollection<Event>(context.Events.GetList()
                .Where(e => e.CityId == SelectedCities &&
                e.Categories.Any(c => c.Id == SelectedCategories) &&
                e.Date >= DateStart &&
                e.Date <= DateEnd));


        }

        private ViewEvent viewEvent = null;
        private void ViewEvent(object obj) 
        {
            if (obj is Event ev)
            {
                if (viewEvent != null) viewEvent.Close();
                viewEvent = new ViewEvent();
                ViewEventViewModel viewModel = new ViewEventViewModel(context.Events.GetItem(ev.Id)); ;
                viewEvent.DataContext = viewModel;
                viewEvent.Show();
            }
        }
        private void ResetEvents(object obj)
        {
            Events = context.Events.GetList();
            SelectedCategories = 1;
            SelectedCities = 1;
        }
    }
}
