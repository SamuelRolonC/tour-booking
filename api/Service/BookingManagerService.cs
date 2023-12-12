using Core.Entity;
using Core.Interface.Repository;
using Core.Interface.Service;

namespace Service
{
    public class BookingManagerService : IBookingManagerService
    {
        private readonly ITourRepository _tourRepository;
        private readonly IBookingRepository _bookingRepository;

        public BookingManagerService(ITourRepository tourRepository
            , IBookingRepository bookingRepository)
        {
            _tourRepository = tourRepository;
            _bookingRepository = bookingRepository;
        }

        public async Task<Tour> CreateTourAsync(Tour tour)
        {
            return await _tourRepository.CreateAsync(tour);
        }

        public async Task<List<Tour>> GetAllTourAsync()
        {
            return await _tourRepository.GetAllAsync();
        }

        public async Task<Booking> BookTourAsync(Booking booking)
        {
            if (booking.TourId >= 0)
                booking.Tour = null;

            return await _bookingRepository.CreateAsync(booking);
        }

        public async Task<List<Booking>> GetAllBookingsAsync()
        {
            return await _bookingRepository.GetAllAsync();
        }

        public async Task<(bool, string)> RemoveBookingAsync(int bookingId)
        {
            return await _bookingRepository.RemoveAsync(bookingId);
        }
    }
}