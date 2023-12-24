﻿using System.Collections.ObjectModel;

namespace UnitTests.DAL
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Event> Events { get; set; } = new();
    }
}
