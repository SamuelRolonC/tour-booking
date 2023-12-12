using Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data;

public partial class TourBookingContext : DbContext
{
    public TourBookingContext()
    {
    }

    public TourBookingContext(DbContextOptions<TourBookingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Tour> Tours { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Booking__3213E83F77C48CA8");

            entity.ToTable("Booking");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Customer)
                .HasMaxLength(255)
                .HasColumnName("customer");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.TourId).HasColumnName("tourId");

            entity.HasOne(d => d.Tour).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.TourId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_booking_tourId");
        });

        modelBuilder.Entity<Tour>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tour__3213E83F1670238E");

            entity.ToTable("Tour");

            entity.HasIndex(e => e.Name, "UQ__Tour__72E12F1BD535D338").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Destination)
                .HasMaxLength(255)
                .HasColumnName("destination");
            entity.Property(e => e.EndDate).HasColumnName("endDate");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(38, 5)")
                .HasColumnName("price");
            entity.Property(e => e.StartDate).HasColumnName("startDate");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
