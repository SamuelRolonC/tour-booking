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
            var tourList = await _context.Tours
                .Select(x => new Tour()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Destination = x.Destination,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Price = x.Price,
                })
                .OrderBy(x => x.StartDate).ThenBy(x => x.EndDate)
                .ToListAsync();
            return tourList;
        }

        public async Task<Tour> GetByIdAsync(int id)
        {
            var tour = await _context.Tours.FirstOrDefaultAsync(x => x.Id == id);
            return tour;
        }

        public async Task<(bool, string)> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

    }
}