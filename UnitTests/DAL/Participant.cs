using System.Collections.ObjectModel;



namespace UnitTests.DAL
{
    public class Participant
    {
        public int Id { get; set; }

        
        public string Name { get; set; }

        
        public string? Email { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }


        
        public List<Participation> Participations { get; set; } = new();
    }
}
