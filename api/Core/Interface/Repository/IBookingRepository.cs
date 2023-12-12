using Core.Entity;

namespace Core.Interface.Repository
{
    public interface IBookingRepository : IBaseRepository<Booking>
    {
        Task<(bool, string)> RemoveAsync(int id);
    }
}
