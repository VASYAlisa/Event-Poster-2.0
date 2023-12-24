using System.Collections.ObjectModel;


namespace Event_Poster_2._0.Model.DAL
{
    public class City
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ObservableCollection<Event> Events { get; set; }
    }
}
