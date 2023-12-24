using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Poster_2._0.Model.DAL
{
    public class ParticipationEvent
    {
        public int Id { get; set; }

        
        public int? ParticipationId { get; set; }

        public Participation? Participation { get; set; }
        
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
