using Core.Entity;
using Core.Interface.Repository;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly TourBookingContext _context;

        public BookingRepository(TourBookingContext context)
        {
            _context = context;

        }

        public async Task<Booking> CreateAsync(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
            return booking;
        }

        public async Task<List<Booking>> GetAllAsync()
        {
            var bookingList = await _context.Bookings
                .Include(x => x.Tour)
                .Select(x => new Booking()
                {
                    Id = x.Id,
                    TourId = x.TourId,
                    Customer = x.Customer,
                    Date = x.Date,
                    Tour = new Tour()
                    {
                        Id = x.Tour.Id,
                        Name = x.Tour.Name,
                        Price = x.Tour.Price
                    },
                })
                .OrderBy(x => x.Date)
                .ToListAsync();
            return bookingList;
        }

        public async Task<(bool, string)> RemoveAsync(int id)
        {
            var booking = await _context.Bookings.FirstOrDefaultAsync(x => x.Id == id);
            
            if (booking == null)
                return (false, "No se encontró la reserva");
            
            _context.Remove(booking);
            await _context.SaveChangesAsync();

            return (true, string.Empty);
        }
    }
}