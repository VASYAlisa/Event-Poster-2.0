using System;
using System.Collections.ObjectModel;

namespace UnitTests.DAL
{
    public class Participation
    {
        public int Id { get; set; }

        
        public DateTime Date { get; set; }
        
        public int Price { get; set; }

        public int ParticipantId { get; set; }
        
        public Participant Participant { get; set; } 

        public int EventId { get; set; }
        

        public Event Event { get; set; }

        public List<Participation> Participations { get; set; } = new();
    }
}
