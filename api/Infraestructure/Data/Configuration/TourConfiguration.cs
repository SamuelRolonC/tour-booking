using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Data.Configuration
{
    public class TourConfiguration : IEntityTypeConfiguration<Tour>
    {
        public void Configure(EntityTypeBuilder<Tour> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__Tour__3213E83F1670238E");

            builder.ToTable("Tour");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Destination)
                .HasMaxLength(255)
                .HasColumnName("destination");
            builder.Property(e => e.EndDate).HasColumnName("endDate");
            builder.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            builder.Property(e => e.Price)
                .HasColumnType("decimal(38, 5)")
                .HasColumnName("price");
            builder.Property(e => e.StartDate).HasColumnName("startDate");
        }
    }
}
