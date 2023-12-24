using Event_Poster_2._0.Model.DAL;
using Event_Poster_2._0.Model.Repositories;
using Event_Poster_2._0.Utilities;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Event_Poster_2._0.ViewModel.UserWindows
{
    public class CreateParticipationViewModel : ViewModelBase
    {
        private DbRepos context;

        private string _wishEvents;
        private int _totalPrice;

        public int TotalPrice
        {
            get { return _totalPrice; }
            set { _totalPrice = value; OnPropertyChanged(nameof(TotalPrice)); }
        }
        public string WishEvents
        {
            get { return _wishEvents; }
            set { _wishEvents = value; OnPropertyChanged(nameof(WishEvents)); }
        }

        public ICommand CreateParticipationCommand { get; set; }

        private Participant curParticipant;
        private ObservableCollection<Event> events;
        public CreateParticipationViewModel(ObservableCollection<Event> _events, Participant participant)
        {
            curParticipant = participant;
            events = _events;
            WishEvents = string.Join(Environment.NewLine, events.Select(p => p.Name)); //
            context = new DbRepos();
            TotalPrice = events.Select(p => p.Price).Sum();

            CreateParticipationCommand = new RelayCommand(CreateParticipation);
        }

        private void CreateParticipation(object obj)
        {
            var participationLines = new ObservableCollection<ParticipationEvent>();
            foreach (Event p in events)
            {
                var ev = context.Events.GetItem(p.Id);
                var line = new ParticipationEvent();
                line.EventId = ev.Id;

                participationLines.Add(line);
            }
            var newParticipation = new Participation
            {
                Date = DateTime.Now,
                ParticipantId = curParticipant.Id,
                Price = TotalPrice,
                ParticipationEvents = participationLines

            };
            context.Participations.Create(newParticipation);

            context.Save();
            if (obj is Window window) window.Close();
        }



    }
}
