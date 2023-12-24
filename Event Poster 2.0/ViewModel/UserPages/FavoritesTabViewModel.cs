using Event_Poster_2._0.Model.DAL;
using Event_Poster_2._0.Utilities;
using Event_Poster_2._0.View.UserWindows;
using Event_Poster_2._0.ViewModel.UserWindows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Event_Poster_2._0.ViewModel.UserPages
{
    public class FavoritesTabViewModel : ViewModelBase
    {
        private ObservableCollection<Event> _events;
        private Participant participant;
        private int _totalPrice;
        private string _errorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); }
        }
        public int TotalPrice
        {
            get { return _totalPrice; }
            set { _totalPrice = value; OnPropertyChanged(nameof(TotalPrice)); }
        }
        public ObservableCollection<Event> EventInWishList
        {
            get { return _events; }
            set { _events = value; OnPropertyChanged(nameof(EventInWishList)); }
        }

        private Participant curUser;
        public ICommand DelEventFromWishListCommand { get; set; }
        public ICommand CreateParticipationCommand { get; set; }

        public FavoritesTabViewModel(ObservableCollection<Event> events, Participant participant)
        {
            curUser = participant;
            EventInWishList= events;
            TotalPrice = EventInWishList.Select(p => p.Price).Sum();

            DelEventFromWishListCommand = new RelayCommand(DelEvent);
            CreateParticipationCommand = new RelayCommand(CreateParticipation);
        }

        CreateParticipation window = null;
        private void CreateParticipation(object obj)
        {
            if (EventInWishList.Count > 0)
            {
                if (window != null) window.Close();
                window = new CreateParticipation();
                CreateParticipationViewModel viewModel = new CreateParticipationViewModel(EventInWishList, curUser);
                window.Closed += (s, e) =>
                {
                    TotalPrice = 0;
                    EventInWishList.Clear();
                };
                window.DataContext = viewModel;
                window.Show();
            }
            else ErrorMessage = "Избранное пусто, вы не можете принять участие";

        }
        private void DelEvent(object obj)
        {
            if (obj is Event delEvent)
            {
                TotalPrice -= delEvent.Price;
                EventInWishList.Remove(delEvent);

            }
        }
    }
}
