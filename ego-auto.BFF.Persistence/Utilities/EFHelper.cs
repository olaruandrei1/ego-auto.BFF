using ego_auto.BFF.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ego_auto.BFF.Persistence.Utilities;

internal static class ModelMapping
{
    private static void User(ModelBuilder modelBuilder)
    => modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users", schema: "public");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.AccountName).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Password).IsRequired();
            entity.Property(e => e.Role).IsRequired().HasMaxLength(20);
        });

    private static void Vehicle(ModelBuilder modelBuilder)
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

    private static void Booking(ModelBuilder modelBuilder)
    => modelBuilder.Entity<Booking>(entity =>
        {
            entity.ToTable("bookings", schema: "public");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.VehicleId).IsRequired();
            entity.Property(e => e.RenterId).IsRequired();
            entity.Property(e => e.StartDate).IsRequired();
            entity.Property(e => e.EndDate).IsRequired();
            entity.Property(e => e.TotalPrice).HasColumnType("numeric(10,2)");
            entity.Property(e => e.Status).IsRequired().HasMaxLength(20);

            entity.HasOne<Vehicle>()
                .WithMany()
                .HasForeignKey(e => e.VehicleId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne<User>()
                .WithMany()
                .HasForeignKey(e => e.RenterId)
                .OnDelete(DeleteBehavior.Restrict);
        });

    private static void Payment(ModelBuilder modelBuilder)
    => modelBuilder.Entity<Payment>(entity =>
        {
            entity.ToTable("payments", schema: "public");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.BookingId).IsRequired();
            entity.Property(e => e.Amount).HasColumnType("numeric(10,2)").IsRequired();
            entity.Property(e => e.PaymentDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.Status).IsRequired().HasMaxLength(20);

            entity.HasOne<Booking>()
                .WithMany()
                .HasForeignKey(e => e.BookingId)
                .OnDelete(DeleteBehavior.Cascade);
        });

    public static void ApplyAllMappings(ModelBuilder modelBuilder)
    {
        Payment(modelBuilder);
        Booking(modelBuilder);
        Vehicle(modelBuilder);
        User(modelBuilder);
    }
}
