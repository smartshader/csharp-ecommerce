using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Catalog.Domain.Repositories;
using Catalog.Domain.Entities;

namespace Catalog.Infrastructure.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly CatalogContext _context;
        
        public IUnitOfWork UnitOfWork => _context;

        public ItemRepository(CatalogContext context)
        {
            _context = context ??
                throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Item>> GetAsync()
        {
            return await _context
                .Items
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Item> GetAsync(Guid id)
        {
            return await _context
                .Items
                .AsNoTracking()
                .Where(Item => Item.Id == id)
                .Include(Item => Item.Genre)
                .Include(Item => Item.Artist)
                .FirstOrDefaultAsync();
        }

        public Item Add(Item item)
        {
            return _context
                .Items
                .Add(item)
                .Entity;
        }

        public Item Update(Item item)
        {
            _context.Entry(item).State = EntityState.Modified;
            return item;
        }
    }
}
