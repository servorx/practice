using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class BranchConfig : IEntityTypeConfiguration<Branch>
{
    public void Configure(EntityTypeBuilder<Branch> builder)
    {
        builder.ToTable("branches");

        // Primary Key
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();
        // ValueObjects -> Columnas
        builder.OwnsOne(b => b.NumberCommercial, numberCommercial =>
        {
            numberCommercial.Property(n => n.Value)
                .HasColumnName("number_comercial")
                .IsRequired();
        });
        builder.OwnsOne(b => b.Address, address =>
        {
            address.Property(a => a.Value)
                .HasColumnName("address")
                .HasMaxLength(80)
                .IsRequired();
        });
        builder.OwnsOne(b => b.Email, email =>
        {
            email.Property(e => e.Value)
                .HasColumnName("email")
                .HasMaxLength(80)
                .IsRequired();
        });
        builder.OwnsOne(b => b.ContactName, name =>
        {
            name.Property(n => n.Value)
                .HasColumnName("contact_name")
                .HasMaxLength(50)
                .IsRequired();
        });
        builder.OwnsOne(b => b.Phone, phone =>
        {
            phone.Property(p => p.Value)
                .HasColumnName("phone")
                .HasMaxLength(15)
                .IsRequired();
        });
        // Relaciones
        builder.HasOne(b => b.City)
            .WithMany()
            .HasForeignKey("city_id")
            .IsRequired();
        builder.HasOne(b => b.Company)
            .WithMany()
            .HasForeignKey("company_id")
            .IsRequired();
    }
}