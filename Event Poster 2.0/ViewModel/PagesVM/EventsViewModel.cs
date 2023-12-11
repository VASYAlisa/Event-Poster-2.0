using Event_Poster_2._0.Model.DAL;
using Event_Poster_2._0.Model.Data;
using Event_Poster_2._0.Utilities;
using Event_Poster_2._0.View.ViewForAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Event_Poster_2._0.ViewModel.PagesVM
{
    public class EventsViewModel : ViewModelBase
    {
        private List<Event> _events;

        public List<Event> Events
        {
            get { return _events; }
            set { _events = value; OnPropertyChanged(nameof(Events));}
        }

        public ICommand AddEventCommand { get; set; }
        EventContext context;
        public EventsViewModel()
        {
            AddEventCommand = new RelayCommand(CreateEvent);
            context = new EventContext();
            Events = context.Events.ToList();
        }

        private void CreateEvent(object obj)
        {
            AddEvent addEvent = new AddEvent();
            AddEventViewModel viewModel = new AddEventViewModel();
            addEvent.DataContext = viewModel;
            addEvent.Show();
        }
    }
}
