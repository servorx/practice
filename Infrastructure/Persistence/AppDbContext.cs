using Domain.Entities;
using Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Country> Countries { get; set; } = null!;
    public DbSet<Region> Regions { get; set; } = null!;
    public DbSet<City> Cities { get; set; } = null!;
    public DbSet<Company> Companies { get; set; } = null!;
    public DbSet<Branch> Branches { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    => modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
}