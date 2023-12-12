using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Data.Configuration
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__Booking__3213E83F77C48CA8");

            builder.ToTable("Booking");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Customer)
                .HasMaxLength(255)
                .HasColumnName("customer");
            builder.Property(e => e.Date).HasColumnName("date");
            builder.Property(e => e.TourId).HasColumnName("tourId");

            builder.HasOne(d => d.Tour).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.TourId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_booking_tourId");
        }
    }
}
