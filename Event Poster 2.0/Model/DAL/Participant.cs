using System.Collections.ObjectModel;



namespace Event_Poster_2._0.Model.DAL
{
    public class Participant
    {
        public int Id { get; set; }

        
        public string Name { get; set; }

        
        public string Email { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }


        
        public ObservableCollection<Participation> Participations { get; set; } = new();
    }
}
