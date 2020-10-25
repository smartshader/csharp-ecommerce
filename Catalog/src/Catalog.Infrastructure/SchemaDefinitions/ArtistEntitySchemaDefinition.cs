using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Catalog.Domain.Entities;

namespace Catalog.Infrastructure.SchemaDefinitions
{
    public class ArtistEntitySchemaDefinition : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.ToTable("Artists", CatalogContext.DEFAULT_SCHEMA);

            builder.HasKey(artist => artist.Id);

            builder.Property(artist => artist.Id);

            builder.Property(artist => artist.Name)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}
