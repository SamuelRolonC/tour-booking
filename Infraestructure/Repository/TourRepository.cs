using Core.Entity;
using Core.Interface.Repository;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repository
{
    public class TourRepository : ITourRepository
    {
        private readonly TourBookingContext _context;

        public TourRepository(TourBookingContext context)
        {
            _context = context;
        }

        public async Task<Tour> CreateAsync(Tour tour)
        {
            await _context.Tours.AddAsync(tour);
            await _context.SaveChangesAsync();
            return tour;
        }

        public async Task<List<Tour>> GetAllAsync()
        {
            var tourList = await _context.Tours.ToListAsync();
            return tourList;
        }
    }
}