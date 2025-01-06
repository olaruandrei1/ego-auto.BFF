using ego_auto.BFF.Domain.Entities;
using ego_auto.BFF.Persistence.Utilities;
using Microsoft.EntityFrameworkCore;

namespace ego_auto.BFF.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Payment> Payment { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    => ModelMapping.ApplyAllMappings(modelBuilder);
}
