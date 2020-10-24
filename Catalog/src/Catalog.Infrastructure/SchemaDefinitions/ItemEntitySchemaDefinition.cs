using System;
using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Infrastructure.SchemaDefinitions
{
    public class ItemEntitySchemaDefinition : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            // ToTable requires Microsoft.EntityFrameworkCore.Relational
            builder.ToTable("Items", CatalogContext.DEFAULT_SCHEMA);

            builder.HasKey(item => item.Id);

            builder.Property(item => item.Name)
                .IsRequired();

            builder.Property(item => item.Description)
                .IsRequired()
                .HasMaxLength(1000);

            builder
                .HasOne(item => item.Genre)
                .WithMany(genre => genre.Items)
                .HasForeignKey(item => item.GenreId);

            builder
                .HasOne(item => item.Artist)
                .WithMany(artist => artist.Items)
                .HasForeignKey(item => item.ArtistId);

            builder.Property(item => item.Price).HasConversion(
                price => $"{price.Amount}:{price.Currency}",
                price => new Price
                {
                    Amount = Convert.ToDecimal(
                            price.Split(':', StringSplitOptions.None)[0]),
                    Currency = price.Split(':', StringSplitOptions.None)[1]
                });
        }
    }
}
