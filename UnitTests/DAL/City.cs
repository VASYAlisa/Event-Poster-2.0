﻿using System.Collections.ObjectModel;


namespace UnitTests.DAL
{
    public class City
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Event> Events { get; set; }
    }
}
