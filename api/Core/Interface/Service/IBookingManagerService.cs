using Core.Entity;

namespace Core.Interface.Service
{
    public interface IBookingManagerService
    {
        Task<Tour> CreateTourAsync(Tour tour);
        Task<List<Tour>> GetAllTourAsync();
        Task<Booking> BookTourAsync(Booking booking);
        Task<List<Booking>> GetAllBookingsAsync();
        Task<(bool, string)> RemoveBookingAsync(int bookingId);
    }
}
