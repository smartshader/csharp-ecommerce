using System;
using System.Threading.Tasks;
using Catalog.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Xunit;

namespace Catalog.Infrastructure.Tests
{
    public class ItemRepositoryTests
    {
        [Fact]
        public async Task should_get_data()
        {
            var options = new DbContextOptionsBuilder<CatalogContext>()
                .UseInMemoryDatabase(databaseName: "should_get_data")
                .Options;
            
            await using var context = new TestCatalogContext(options);
            context.Database.EnsureCreated();
            
            var sut = new ItemRepository(context);
            var result = await sut.GetAsync();
            
            result.ShouldNotBeNull();
        }

        [Fact]
        public async Task should_returns_null_with_id_not_present()
        {
            var options = new DbContextOptionsBuilder<CatalogContext>()
                .UseInMemoryDatabase(databaseName: "should_returns_null_with_id_not_present")
                .Options;
            
            await using var context = new TestCatalogContext(options);
            context.Database.EnsureCreated();
            
            var sut = new ItemRepository(context);
            var result = await sut.GetAsync(Guid.NewGuid());
            
            result.ShouldBeNull();
        }
    }
}