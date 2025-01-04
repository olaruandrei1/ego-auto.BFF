using ego_auto.BFF.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ego_auto.BFF.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    => modelBuilder.Entity<Vehicle>(entity =>
       {
            entity.ToTable("vehicles", schema: "public");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Make).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Model).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Year).IsRequired();
            entity.Property(e => e.PricePerDay).HasColumnType("numeric(10,2)");
            entity.Property(e => e.Status).IsRequired().HasMaxLength(20);
            entity.Property(e => e.Description).IsRequired(false);
        });

}
