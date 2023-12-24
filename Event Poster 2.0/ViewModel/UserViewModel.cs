using Event_Poster_2._0.Model.DAL;
using Event_Poster_2._0.Model.Repositories;
using Event_Poster_2._0.Utilities;
using Event_Poster_2._0.ViewModel.AdminPages;
using Event_Poster_2._0.ViewModel.UserPages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Event_Poster_2._0.ViewModel
{
    public class UserViewModel : ViewModelBase
    {
        private object _currentView;
        private Participant _participant;
        private ObservableCollection<Event> _eventsInWishList;
        public ObservableCollection<Event> Events { get { return _eventsInWishList; } set { _eventsInWishList = value; OnPropertyChanged(nameof(Events)); } }
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(nameof(CurrentView)); }
        }

        public Participant Participant
        {
            get { return _participant; }
            set { _participant = value; OnPropertyChanged(nameof(Participant)); }
        }
        public ICommand CatalogCommand { get; set; }
        public ICommand FavoritesTabCommand { get; set; }
        public ICommand HomeCommand { get; set; }
        

        private void Catalog(object obj) => CurrentView = new CatalogViewModel(this);
        private void FavoritesTab(object obj) => CurrentView = new FavoritesTabViewModel(Events,Participant);
        private void Home(object obj) => CurrentView = new HomeViewModel(Participant);
        

        private DbRepos context;
        public UserViewModel(User user)
        {
            context = new DbRepos();
            Events = new ObservableCollection<Event>();

            var participant = context.Participants.GetList().FirstOrDefault(i => i.UserId == user.Id);
            if (participant != null) Participant = participant;

            CatalogCommand = new RelayCommand(Catalog);
            FavoritesTabCommand = new RelayCommand(FavoritesTab);
            HomeCommand = new RelayCommand(Home);

            CurrentView = new CatalogViewModel(this);
        }
    }
}
