using Event_Poster_2._0.Model.DAL;
using Event_Poster_2._0.Model.Data;
using Event_Poster_2._0.Model.Repositories;
using Event_Poster_2._0.Utilities;
using Event_Poster_2._0.View.ViewForAdmin;
using Event_Poster_2._0.ViewModel.CRUD;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Event_Poster_2._0.ViewModel.AdminPages
{
    public class EventsViewModel : ViewModelBase
    {
             
        private ObservableCollection<Event> _events;

        public ObservableCollection<Event> Events
        {
            get { return _events; }
            set { _events = value; OnPropertyChanged(nameof(Events));}
        }

        public ICommand AddEventCommand { get; set; }
        public ICommand EditEventCommand { get; set; }

        private DbRepos context;
        public EventsViewModel()
        {
            context = new DbRepos();

            AddEventCommand = new RelayCommand(CreateEvent);
            EditEventCommand= new RelayCommand(EditEvent);
            
            Events = context.Events.GetList();
        }

        private void EditEvent(object obj)
        {
            if (obj is Event ev)
            {
                EditEvent editEvent = new EditEvent();
                EditEventViewModel viewModel = new EditEventViewModel(ev);
                editEvent.DataContext = viewModel;
                editEvent.Closed += (s, e) =>
                {
                    editEvent.Closed += (s, e) => Events = context.Events.GetList();
                };
                editEvent.Show();
            }
        }

        private void CreateEvent(object obj)
        {
            AddEvent addEvent = new AddEvent();
            AddEventViewModel viewModel = new AddEventViewModel();
            addEvent.DataContext = viewModel;
            addEvent.Closed += (s, e) => Events = context.Events.GetList();
            addEvent.Show();
        }
    }
}
