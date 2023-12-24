using System;
using System.Collections.ObjectModel;

namespace Event_Poster_2._0.Model.DAL
{
    public class Participation
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }
        
        public int Price { get; set; }

        public int ParticipantId { get; set; }
        
        public Participant Participant { get; set; }


        public ObservableCollection<ParticipationEvent> ParticipationEvents { get; set; }
    }
}
