using System;
using System.Collections.Generic;

namespace Catalog.Domain.Entities
{
    public class Artist
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}
