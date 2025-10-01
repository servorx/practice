using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class CompanyConfig : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("companies");

        // Primary Key
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        // ValueObjects -> Columnas
        builder.OwnsOne(c => c.Name, name =>
        {
            name.Property(n => n.Value)
                .HasColumnName("name")
                .HasMaxLength(120)
                .IsRequired();
        });
        builder.OwnsOne(c => c.UkNiu, ukNiu =>
        {
            ukNiu.Property(n => n.Value)
                .HasColumnName("uk_niu")
                .IsRequired();
        });
        builder.OwnsOne(c => c.Address, address =>
        {
            address.Property(a => a.Value)
                .HasColumnName("address")
                .HasMaxLength(80)
                .IsRequired();
        });
        builder.OwnsOne(c => c.Email, email =>
        {
            email.Property(e => e.Value)
                .HasColumnName("email")
                .HasMaxLength(80)
                .IsRequired();
        });

        // Relaciones
        builder.HasOne(c => c.City)
            .WithMany()
            .HasForeignKey("city_id")
            .IsRequired();
    }
}