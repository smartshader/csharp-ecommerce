using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Catalog.Domain.Entities;

namespace Catalog.Infrastructure.SchemaDefinitions
{
    public class GenreEntitySchemaDefinition : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("Genres", CatalogContext.DEFAULT_SCHEMA);

            builder.HasKey(genre => genre.Id);

            builder.Property(genre => genre.Id);

            builder.Property(genre => genre.Description)
                .IsRequired()
                .HasMaxLength(1000);
        }
    }
}
