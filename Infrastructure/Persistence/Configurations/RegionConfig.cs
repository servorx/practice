using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;
public class RegionConfig : IEntityTypeConfiguration<Region>
{
    public void Configure(EntityTypeBuilder<Region> builder)
    {
        builder.ToTable("regions");

        // Primary Key
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        // ValueObjects -> Columnas
        builder.OwnsOne(r => r.Name, name =>
        {
            name.Property(n => n.Value)
                .HasColumnName("name")
                .HasMaxLength(60)
                .IsRequired();
        });

        // Relaciones
        builder.HasOne(r => r.Country)
            .WithMany()
            .HasForeignKey("country_id")
            .IsRequired();
    }
}