using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Practice.Infrastructure.Persistence.Configurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // definir el nombre de la tabla
            builder.ToTable("users");
            // Primary Key
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();
            // Value Object -> Column
            builder.OwnsOne(u => u.Name, name =>
            {
                name.Property(n => n.Value)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsRequired();
            });
            builder.OwnsOne(u => u.Email, email =>
            {
                email.Property(e => e.Value)
                    .HasColumnName("email")
                    .HasMaxLength(80)
                    .IsRequired();
            });
            builder.OwnsOne(u => u.PasswordHash, password =>
            {
                password.Property(p => p.Value)
                    .HasColumnName("password_hash")
                    .HasMaxLength(128)
                    .IsRequired();
            });
            builder.OwnsOne(u => u.Role, role =>
            {
                role.Property(r => r.Value)
                    .HasColumnName("role")
                    .HasMaxLength(10)
                    .IsRequired();
            });

        }
    }
}