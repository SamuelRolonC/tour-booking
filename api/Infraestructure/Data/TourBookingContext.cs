using Core.Entity;
using Infraestructure.Data.Configuration;
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
        modelBuilder.ApplyConfiguration(new TourConfiguration());
        modelBuilder.ApplyConfiguration(new BookingConfiguration());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
