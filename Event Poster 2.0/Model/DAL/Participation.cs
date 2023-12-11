using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Poster_2._0.Model.DAL
{
    public class Participation
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Дата")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yy  hh:mm}")]
        public DateTime Date { get; set; }
        [DisplayName("Стоимость")]
        public int Price { get; set; }

        public int ParticipantId { get; set; }
        //[ValidateNever]
        [DisplayName("Имя участника")]
        public Participant Participant { get; set; }

        public int EventId { get; set; }
        [DisplayName("События")]

        public List<Participation> Participations { get; set; } = new();
    }
}
