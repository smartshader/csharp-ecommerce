using System;
using System.Collections.Generic;

namespace Catalog.Domain.Entities
{
    public class Genre
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}
