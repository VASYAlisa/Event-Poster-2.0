using System.Collections.Generic;
using System.ComponentModel;


namespace Event_Poster_2._0.Model.DAL
{
    public class Participant
    {
        public int Id { get; set; }

        [DisplayName("Имя")]
        public string Name { get; set; }

        [DisplayName("E-mail")]
        public string? Email { get; set; }

        public int UserId { get; set; }


        //[ValidateNever]
        public List<Participation> Participations { get; set; } = new();
    }
}
