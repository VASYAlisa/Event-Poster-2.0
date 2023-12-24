using System.Collections.ObjectModel;

namespace UnitTests.DAL
{
    public class Status
    {
        
        public int Id { get; set; }

        
        public string Name { get; set; }

        public List<Event> Events { get; set; }
    }
}
