using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Catalog.Infrastructure;

namespace Catalog.API.Extensions
{
    public static class DatabaseExtension
    {
        public static IServiceCollection AddCatalogContext(
            this IServiceCollection services, IConfiguration config)
        {
            return services
                .AddDbContext<CatalogContext>(contextOptions =>
                    contextOptions.UseNpgsql(config.GetConnectionString("DefaultConnection")));
        }
    }
}
